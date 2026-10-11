namespace Summary.IdealCrm.Services
{
    using Dapper;
    using Microsoft.Extensions.Options;
    using Core.Data;
    using Core.Mvc.Utilities;
    using Core.Workflows;
    using Summary.IdealCrm.Settings;
    using Summary.IdealCrm.Workflows.Task.Project.Details.GetBy;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProjectService
    {
        Task<string> CreateAsync(
            string userName,
            string password,
            string companyId,
            string title,
            string inquiryNumber,
            string desc,
            DateTime? startDateTime,
            string starterUser,
            string grade,
            string priority,
            string group,
            string cnvsStatusGroup,
            string postFix,
            DateTime? remindDateTime,
            bool isTicket,
            string cmpPresentation,
            bool isFinished,
            string campaign,
            string creatorUser
        );

        Task<ProjectInfo> GetDetailsByIdAsync(
            string userName,
            string password,
            string projectId
        );

        Task UpdateAsync(
            string userName,
            string password,
            string filter,
            string title,
            bool titleEditable,
            string desc,
            bool descEditable,
            DateTime? startDate,
            bool startDateEditable,
            string starterUser,
            bool starterUserEditable,
            string grade,
            bool gradeEditable,
            string priority,
            bool priorityEditable,
            string group,
            bool groupEditable,
            string cnvsStatusGroup,
            bool CnvsStatusGroupEditable,
            string postFix,
            bool postFixEditable,
            DateTime? remindDateTime,
            bool remindDateTimeEditable,
            string cmpPresentation,
            bool cmpPresentationEditable,
            bool isFinished,
            bool IsFinishedEditable
        );

        Task<IList<ProjectInfo>> GetProjectsByAsync(
            string userName,
            string password,
            string filter,
            ProjectSearchKind searchkind
        );
    }

    public class ProjectService : IProjectService
    {
        private readonly HttpRequestClient _client;
        private readonly IDbConnectionAccessor _db;
        private readonly IdealCrmSettings _options;
        private readonly IIdentityService _identity;
        private readonly IUserService _user;

        public ProjectService(HttpRequestClient client,
            IDbConnectionAccessor db,
            IOptions<IdealCrmSettings> options,
            IIdentityService identity,
            IUserService user)
        {
            _client = client;
            _db = db;
            _options = options.Value;
            _identity = identity;
            _user = user;
        }

        private async Task<string> GetIdByAsync(string userName,
            string password,
            ProjectSearchKind searchKind,
            string filter)
        {
            var data = new Dictionary<string, string>
            {
                { "UserName", userName },
                { "Password", password }
            };

            switch (searchKind)
            {
                case ProjectSearchKind.Title: data.Add("ApiPrjTitle", filter); break;
                case ProjectSearchKind.InquiryNumber:
                {
                    using (var connection = _db.CreateConnection())
                    {
                        connection.ConnectionString = _options.ConnectionString;
                        await connection.OpenAsync();
                        using (var transaction = connection.BeginTransaction())
                        {
                            var query = $"select p.ProjectID from dbo.CrmProjects as p where  p.prjInquiryNum = '{filter}';";
                            int? id = await connection.QueryFirstOrDefaultAsync<int?>(query, null, transaction);

                            return id?.ToString();
                        }
                    }
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchKind));
            }

            var prj = await _client.SendPostRequestAsync<GetProjectIdResponseModel>(
                $"{_options.ApiAddress}/Api/ApiProject/ReturnProjectId",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            return prj.Data.ProjectID;
        }

        private async Task<IList<ProjectInfo>> GetProjectsByCompanyIdAsync(
            string userName,
            string password,
            string companyId)
        {
            var data = new
            {
                UserName = userName,
                Password = password,
                ApiCompanyId = companyId
            };

            var projInfo = await _client.SendPostRequestAsync<BaseInformationResultModel<ProjectInfo>>(
                $"{_options.ApiAddress}/Api/ApiProject/Select",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            return projInfo.Data;
        }

        private async Task<int> GetGradeIdAsync(
            string userName,
            string password,
            string name)
        {
            var grades = await _client.SendPostRequestAsync<BaseInformationResultModel<ProjectGradeInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectProjectGrade",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return grades.Data.First(x => x.ApiProjectGrade.Equals(name)).ApiProjectGradeID;
        }

        private async Task<int> GetGroupIdAsync(
            string userName,
            string password,
            string name)
        {
            var groups = await _client.SendPostRequestAsync<BaseInformationResultModel<ProjectGroupInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectProjectGroups",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return groups.Data.First(x => x.ApiProjectGroup.Equals(name)).ApiProjectGroupID;
        }

        private async Task<int?> GetConversationStatusGroupIdAsync(string filter)
        {
            if (String.IsNullOrWhiteSpace(_options.ConnectionString)) return default;

            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $"select top 1 csg.ConversationStatusGroupID from CrmConversationStatusGroups as csg " +
                                $"where csg.ConversationStatusGroup = N'{filter}';";
                    return await connection.QueryFirstAsync<int>(query, null, transaction, null, CommandType.Text);
                }
            }
        }

        private async Task<int> GetPriorityIdAsync(
            string userName,
            string password,
            string name)
        {
            var priorities = await _client.SendPostRequestAsync<GetPriorityResponseModel<ProjectPriorityInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectProjectPriority",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return priorities.Data.First(x => x.ApiPriority.Equals(name)).ApiProjectPriorityID;
        }

        public async Task<string> CreateAsync(
            string userName,
            string password,
            string companyId,
            string title,
            string inquiryNumber,
            string desc,
            DateTime? startDateTime,
            string starterUser,
            string grade,
            string priority,
            string group,
            string cnvsStatusGroup,
            string postFix,
            DateTime? remindDateTime,
            bool isTicket,
            string cmpPresentation,
            bool isFinished,
            string campaign,
            string creatorUser)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            creatorUser = String.IsNullOrWhiteSpace(creatorUser) ? _options.DefaultCreatorUser : creatorUser;

            int gradeId = grade.ConvertTo<int>() ?? await GetGradeIdAsync(userName, password, grade);
            int priorityId = priority.ConvertTo<int>() ?? await GetPriorityIdAsync(userName, password, priority);
            int groupId = group.ConvertTo<int>() ?? await GetGroupIdAsync(userName, password, group);
            int? cnvsStatusGroupId = cnvsStatusGroup.ConvertTo<int>() ?? await GetConversationStatusGroupIdAsync(cnvsStatusGroup);
            int starterUserId = starterUser.ConvertTo<int>() ?? await _user.GetUserIdAsync(starterUser);
            int? presentationId = cmpPresentation.ConvertTo<int>() ?? await _identity.GetPresentationIdByAsync(cmpPresentation);
            int? creatorUserId = null;

            if (String.IsNullOrWhiteSpace(creatorUser) is false)
            {
                creatorUserId = creatorUser.ConvertTo<int>() ?? await _user.GetUserIdAsync(creatorUser);
            }

            IEnumerable<string> campaign_ids = null;

            if (String.IsNullOrWhiteSpace(campaign) is false)
            {
                campaign_ids = await _identity.GetCampaignIdsAsync(campaign.Split(',', '،', StringSplitOptions.RemoveEmptyEntries));
            }

            var proj_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiProject/Insert",
                new
                {
                    UserName = userName,
                    Password = password,
                    ApiCompanyId = companyId,
                    ApiPrjTitle = title,
                    ApiPrjDesc = desc,
                    ApiPrjStartDateTime = startDateTime?.ToString("yyyy/MM/dd"),
                    ApiPrjStarterUserId = starterUserId,
                    ApiPrjGradeId = gradeId,
                    ApiPrjPriorityId = priorityId,
                    ApiPrjGroupId = groupId,
                    ApiPrjCnvsStatusGroupId = cnvsStatusGroupId,
                    ApiPrjPostFix = postFix,
                    ApiPrjRemindDateTime = remindDateTime?.ToString("yyyy/MM/dd HH:mm:ss"),
                    ApiPrjIsTicket = isTicket,
                    ApiPrjCmpPresentationId = presentationId,
                    ApiPrjIsFinished = isFinished,
                    ApiPrjCmpCampaignIds = campaign_ids is null ? String.Empty : String.Join(',', campaign_ids),
                    UserId = creatorUserId
                },
                null,
                "application/x-www-form-urlencoded"
            );

            DbConnection db = null;
            DbTransaction tran = null;

            if (String.IsNullOrWhiteSpace(_options.ConnectionString) is false)
            {
                var query = $"update p set p.prjInquiryNum = '{inquiryNumber}' from dbo.CrmProjects as p where p.ProjectID = {proj_response.Data};";

                try
                {
                    db = _db.CreateConnection();
                    db.ConnectionString = _options.ConnectionString;
                    await db.OpenAsync();
                    tran = db.BeginTransaction();
                    await db.ExecuteAsync(query, null, tran, null, CommandType.Text);
                    await tran.CommitAsync();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    tran?.Dispose();
                    db?.Dispose();
                }
            }

            if (proj_response.Status == Status.Success) return proj_response.Data;

            else throw new NotImplementedException(proj_response.Message);
        }

        public async Task<ProjectInfo> GetDetailsByIdAsync(
            string userName,
            string password,
            string projectId)
        {
            var data = new
            {
                UserName = userName,
                Password = password,
                ApiProjectId = projectId
            };

            var projInfo = await _client.SendPostRequestAsync<BaseInformationResultModel<ProjectInfo>>(
                $"{_options.ApiAddress}/Api/ApiProject/Select",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            return projInfo.Data.Single();
        }

        public async Task UpdateAsync(
            string userName,
            string password,
            string filter,
            string title,
            bool titleEditable,
            string desc,
            bool descEditable,
            DateTime? startDate,
            bool startDateEditable,
            string starterUser,
            bool starterUserEditable,
            string grade,
            bool gradeEditable,
            string priority,
            bool priorityEditable,
            string group,
            bool groupEditable,
            string cnvsStatusGroup,
            bool CnvsStatusGroupEditable,
            string postFix,
            bool postFixEditable,
            DateTime? remindDateTime,
            bool remindDateTimeEditable,
            string cmpPresentation,
            bool cmpPresentationEditable,
            bool isFinished,
            bool IsFinishedEditable)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            var creator_user = _options.DefaultCreatorUser;

            var user_id = await _user.GetUserIdAsync(creator_user);

            var projDetails = await GetDetailsByIdAsync(
                userName,
                password,
                filter
            );

            var data = new Dictionary<string, object>
            {
                { "UserName", userName },
                { "Password", password },
                { "ApiProjectId", filter },
                { "ApiCompanyId", projDetails.ApiPrjCompanyId },
                { "UserId", user_id }
            };

            if (titleEditable) data.Add("ApiPrjTitle", title);
            if (descEditable) data.Add("ApiPrjDesc", desc);
            if (startDateEditable) data.Add("ApiPrjStartDateTime", startDate?.ToString("yyyy/MM/dd"));

            if (starterUserEditable)
            {
                int starterUserId = starterUser.ConvertTo<int>() ?? await _user.GetUserIdAsync(starterUser);
                data.Add("ApiPrjStarterUserId", starterUserId);
            }

            if (gradeEditable)
            {
                int gradeId = grade.ConvertTo<int>() ?? await GetGradeIdAsync(userName, password, grade);
                data.Add("ApiPrjGradeId", gradeId);
            }

            if (priorityEditable)
            {
                int priorityId = priority.ConvertTo<int>() ?? await GetPriorityIdAsync(userName, password, priority);
                data.Add("ApiPrjPriorityId", priorityId);
            }

            if (groupEditable)
            {
                int groupId = group.ConvertTo<int>() ?? await GetGroupIdAsync(userName, password, group);
                data.Add("ApiPrjGroupId", groupId);
            }

            if (CnvsStatusGroupEditable)
            {
                int? cnvsStatusGroupId = cnvsStatusGroup.ConvertTo<int>() ?? await GetConversationStatusGroupIdAsync(cnvsStatusGroup);
                data.Add("ApiPrjCnvsStatusGroupId", cnvsStatusGroupId);
            }

            if (postFixEditable)
                data.Add("ApiPrjPostFix", postFix);

            if (remindDateTimeEditable)
                data.Add("ApiPrjRemindDateTime", remindDateTime?.ToString("yyyy/MM/dd HH:mm:ss"));

            if (cmpPresentationEditable)
            {
                data.Add(
                    "ApiPrjCmpPresentationId",
                    cmpPresentation.ConvertTo<int>() ?? await _identity.GetPresentationIdByAsync(cmpPresentation)
                );
            }

            if(IsFinishedEditable) data.Add("ApiPrjIsFinished", isFinished);

            var proj_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiProject/Update",
                data,
                null,
                "application/x-www-form-urlencoded");

            if (proj_response.Status == Status.Success) return;
            else
                throw new NotImplementedException(proj_response.Message);
        }

        public async Task<IList<ProjectInfo>> GetProjectsByAsync(
            string userName,
            string password,
            string filter,
            ProjectSearchKind searchKind)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;

            if (searchKind is ProjectSearchKind.IdentityId)
                return await GetProjectsByCompanyIdAsync(userName, password, filter);

            var id = searchKind switch
            {
                ProjectSearchKind.Id => filter,
                ProjectSearchKind.InquiryNumber => await GetIdByAsync(userName, password, searchKind, filter),
                ProjectSearchKind.Title => await GetIdByAsync(userName, password, searchKind, filter),
                _ => throw new NotImplementedException()
            };

            if (String.IsNullOrWhiteSpace(id)) return new List<ProjectInfo>();
            else
            {
                return new List<ProjectInfo>
                {
                    await GetDetailsByIdAsync(userName, password, id)
                };
            }
        }
    }
}