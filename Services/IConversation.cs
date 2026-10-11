namespace Summary.IdealCrm.Services
{
    using Dapper;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Core.Data;
    using Core.Mvc.Utilities;
    using Core.Workflows;
    using Summary.IdealCrm.Settings;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IConversationService
    {
        Task<string> CreateAsync(
            string userName,
            string password,
            string companyId,
            string personId,
            string projectId,
            DateTime? date,
            string type,
            string desc,
            string creatorUser,
            string referUser,
            string status,
            string priority,
            DateTime? remindDate,
            DateTime? alarmDate,
            string remindTime,
            bool isRemind,
            bool isBookMark,
            string doingTime
        );
    }

    public class ConversationService : IConversationService
    {
        private readonly HttpRequestClient _client;
        private readonly IDbConnectionAccessor _db;
        private readonly IdealCrmSettings _options;
        private readonly IProjectService _project;
        private readonly ILogger<ConversationService> _logger;

        public ConversationService(HttpRequestClient client,
            IDbConnectionAccessor db,
            IOptions<IdealCrmSettings> options,
            IProjectService project,
            ILogger<ConversationService> logger)
        {
            _client = client;
            _db = db;
            _options = options.Value;
            _project = project;
            _logger = logger;
        }

        private async Task<IList<ConversationStatusInfo>> GetStatusAsync(
            string userName,
            string password,
            int groupId)
        {
            var statuses = await _client.SendPostRequestAsync<BaseInformationResultModel<ConversationStatusInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectConversationStatus",
                new
                {
                    UserName = userName,
                    Password = password,
                    ApiGroupId = groupId,
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return statuses.Data;
        }

        // Get StatusId by StatusProgressPercent
        private async Task<int> GetStatusIdByAsync(
            string userName,
            string password,
            int groupId,
            int percentage)
        {
            var statuses = await GetStatusAsync(userName, password, groupId);

            return statuses.First(x => x.ApiProgressPercent == percentage).ApiConversationStatusID;
        }

        // Get StatusId by StatusName
        private async Task<int> GetStatusIdByAsync(
            string userName,
            string password,
            int groupId,
            string name)
        {
            var statuses = await GetStatusAsync(userName, password, groupId);

            return statuses.First(x => x.ApiStatus.Equals(name)).ApiConversationStatusID;
        }

        private async Task<int> GetPriorityIdByAsync(
            string userName,
            string password,
            string name)
        {
            var url = $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectConversationPriority";

            var data = new
            {
                UserName = userName,
                Password = password
            };

            var priorities = await _client.SendPostRequestAsync<GetPriorityResponseModel<ConversationPriorityInfo>>(
                url,
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            var priority = priorities.Data.FirstOrDefault(x => x.ApiPriority.Equals(name));

            if (priority is null) throw new WorkflowException(
                "مقدار فیلد وارد شده اولویت نمایش نامعتبر است.",
                null,
                name,
                "کاربر گرامی؛ مقدار فیلد اولویت نمایش در تسک رویداد پروژه که برای ثبت پروژه استفاده نموده اید نامعتبر است. مقادیر معتبر فیلد اولویت نمایش بدین شرح می‌باشند: " + string.Join(", ", priorities.Data.Select(x => x.ApiPriority)),
                Level.Information
            );

            else return priority.ApiConversationPriorityID;
        }

        private async Task<int> GetTypeIdByAsync(
            string userName,
            string password,
            string name)
        {
            var types = await _client.SendPostRequestAsync<BaseInformationResultModel<ConversationTypeInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectConversationTopics",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return types.Data.First(x => x.ApiTopic.Equals(name)).ApiConversationTopicsID;
        }

        private async Task<int> GetUserIdByAsync(
            string userName,
            string password,
            string name)
        {
            var user = await _client.SendPostRequestAsync<BaseInformationResultModel<UserInfo>>(
                $"{_options.ApiAddress}/Api/ApiUser/Select",
                new
                {
                    UserName = userName,
                    Password = password,
                    ApiUserName = name
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return user.Data.Single().ApiUserId;
        }

        public async Task<string> CreateAsync(
            string userName,
            string password,
            string companyId,
            string personId,
            string projectId,
            DateTime? date,
            string type,
            string desc,
            string creatorUser,
            string referUser,
            string status,
            string priority,
            DateTime? remindDate,
            DateTime? alarmDate,
            string remindTime,
            bool isRemind,
            bool isBookMark,
            string doingTime)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            string _creatorUser = String.IsNullOrWhiteSpace(_options.DefaultCreatorUser) ? creatorUser : _options.DefaultCreatorUser;

            var prjGroupId = await _project.GetDetailsByIdAsync(
                userName,
                password,
                projectId
            );

            int statusId;

            if (int.TryParse(status, out int percentage))
            {
                statusId = await GetStatusIdByAsync(
                    userName,
                    password,
                    prjGroupId.ApiPrjcnvsStatusGroupId,
                    percentage: percentage);
            }
            else
            {
                statusId = await GetStatusIdByAsync(
                    userName,
                    password,
                    prjGroupId.ApiPrjcnvsStatusGroupId,
                    name: status);
            }

            int priorityId = priority.ConvertTo<int>() ?? await GetPriorityIdByAsync(
                userName,
                password,
                priority
            );

            int typeId = type.ConvertTo<int>() ?? await GetTypeIdByAsync(
                userName,
                password,
                type
            );

            int creatorUserId = creatorUser.ConvertTo<int>() ?? await GetUserIdByAsync(
                userName,
                password,
                creatorUser
            );

            int referUserId = referUser.ConvertTo<int>() ?? await GetUserIdByAsync(
                userName,
                password,
                referUser
            );

            int _creatorUserId = _creatorUser.ConvertTo<int>() ?? await GetUserIdByAsync(
                userName,
                password,
                _creatorUser
            );

            var data = new
            {
                UserName = userName,
                Password = password,
                ApiCompanyId = companyId,
                ApiPersonId = personId,
                ApiProjectId = projectId,
                ApiCnvsDateTime = date?.ToString("yyyy/MM/dd HH:mm:ss"),
                ApiCnvsTopicId = typeId,
                ApiCnvsDesc = desc,
                ApiCnvsUserId = creatorUserId,
                ApiCnvsReferUserId = referUserId,
                ApiCnvsStatusId = statusId,
                ApiCnvsPriorityId = priorityId,
                ApiCnvsRemindDateTime = remindDate?.ToString("yyyy/MM/dd"),
                ApiCnvsRemindDateTimeForAllarm = alarmDate?.ToString("yyyy/MM/dd"),
                ApiCnvsRemindTime = remindTime,
                ApiCnvsRemindOk = isRemind,
                ApiCnvsIsBookMark = isBookMark,
                ApiCnvsDoingTime = doingTime,
                UserId = _creatorUserId
            };

            var response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiConversation/Insert",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            if (response.Status is Status.Success) return response.Data;
            else
            {
                _logger.LogError(JsonConvert.SerializeObject(data));
                throw new NotImplementedException(response.Message);
            }
        }
    }
}