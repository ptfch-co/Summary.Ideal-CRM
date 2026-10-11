namespace Summary.IdealCrm.Services
{
    using Dapper;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Core.Data;
    using Core.Workflows;
    using Summary.IdealCrm.Settings;
    using Summary.IdealCrm.Workflows.Task.Person.Details.GetBy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public interface IPersonService
    {
        Task<PersonInfo> GetDetailsByAsync(
            string userName,
            string password,
            string filter,
            PersonSearchKind searchKind
        );
    }

    public class PersonService : BaseService, IPersonService
    {
        private readonly HttpRequestClient _client;
        private readonly IdealCrmSettings _options;
        private readonly IDbConnectionAccessor _db;
        private readonly ILogger<PersonService> _logger;

        public PersonService(HttpRequestClient client,
            IOptions<IdealCrmSettings> options,
            IDbConnectionAccessor db,
            ILogger<PersonService> logger)
        {
            _client = client;
            _options = options.Value;
            _db = db;
            _logger = logger;
        }

        private async Task<string> GetIdByMobileNoAsync(string mobile)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var tran = connection.BeginTransaction())
                {
                    return await connection.QueryFirstOrDefaultAsync<string>(
                        $"select top 1 p.CompanyPersonID from dbo.CrmCompanyPersons as p where p.prsMobile like N'%{Regex.Replace(mobile, MOBILE_REGEX_FORMAT, String.Empty)}%';",
                        null,
                        tran
                    );
                }
            }
        }

        private async Task<string> GetIdByAsync(
            string userName,
            string password,
            PersonSearchKind searchKind,
            string filter)
        {
            if (String.IsNullOrWhiteSpace(filter)) return null;

            var data = new Dictionary<string, string>
            {
                { "UserName", userName },
                { "Password", password }
            };

            if (searchKind is PersonSearchKind.Mobile) return await GetIdByMobileNoAsync(filter);

            switch (searchKind)
            {
                case PersonSearchKind.NationalCode: data.Add("ApiPrsNationalCode", filter); break;
                case PersonSearchKind.Email: data.Add("ApiPrsEmail", filter); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchKind));
            }

            var prs = await _client.SendPostRequestAsync<GetPersonIdResponseModel>(
                $"{_options.ApiAddress}/Api/ApiCompanyPerson/ReturnCompanyPersonId",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            return prs.Data?.CompanyPersonID;
        }

        public async Task<PersonInfo> GetDetailsByAsync(
            string userName,
            string password,
            string filter,
            PersonSearchKind searchKind)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;

            string personId;
            if (searchKind is PersonSearchKind.Id)
            {
                personId = filter;
            }
            else
            {
                personId = await GetIdByAsync(
                    userName,
                    password,
                    searchKind,
                    filter
                );
            }

            if (String.IsNullOrWhiteSpace(personId)) return null;

            var personDetails = await _client.SendPostRequestAsync<BaseInformationResultModel<PersonInfo>>(
                $"{_options.ApiAddress}/Api/ApiCompanyPerson/Select",
                new
                {
                    UserName = userName,
                    Password = password,
                    ApiCompanyPersonId = personId,
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return personDetails.Data.Single();
        }
    }
}