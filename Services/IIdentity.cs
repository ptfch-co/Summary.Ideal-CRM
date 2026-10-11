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
    using Summary.IdealCrm.Workflows.Task.Identity.UpdateBy;
    using Summary.IdealCrm.Workflows.Task.Person.Details.GetBy;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public interface IIdentityService
    {
        Task<bool> CheckMobileIsExistAsync(string mobile);
        Task<CreateIdentityResponseInfo> CreateIdentityAsync(CreateOrganizationRequestInfo org, CreatePersonRequestInfo person);
        Task<IEnumerable<string>> GetCampaignIdsAsync(string[] names);
        Task UpdateAsync(
            IdentitySearchKind searchKind,
            string userName,
            string password,
            string filter,
            bool isIdentityTypeEditable,
            string identityType,
            bool isSubjectEditable,
            string subject,
            bool isTypeEditable,
            string type,
            bool isCountryEditable,
            string country,
            bool isProvinceEditable,
            string province,
            bool isCityEditable,
            string city,
            bool isMobileEditable,
            string mobile,
            bool isFirstNameEditable,
            string firstName,
            bool isLastNameEditable,
            string lastName,
            bool isDescriptionEditable,
            string description,
            bool isAddressEditable,
            string address,
            bool isGroup_1Editable,
            string group_1,
            bool isPresentationEditable,
            string presentation,
            bool isNationalIdEditable,
            string nationalId,
            bool isEconomicCodeEditable,
            string economicCode,
            bool isRegisterNumberEditable,
            string registerNumber,
            bool isPostalCodeEditable,
            string postalCode,
            bool isPostalBoxEditable,
            string postalBox,
            bool isCmpEmailEditable,
            string cmpEmail,
            bool isCmpPhoneEditable,
            string cmpPhone,
            bool isJobEditable,
            string job,
            bool isDepartmentEditable,
            string department,
            bool isPrsEmailEditable,
            string prsEmail,
            bool isNationalCodeEditable,
            string nationalCode,
            bool isPrsAddressEditable,
            string prsAddress,
            bool isPrsDescriptionEditable,
            string prsDescription,
            bool isPrsPhoneEditable,
            string prsPhone,
            bool isAssignToEditable,
            string assignTo,
            bool isCampaignEditable,
            bool addToCampaign,
            string campaign
        );
        Task<int> GetUserIdAsync(string user);
        Task<IList<IdentityResponseInfo>> SyncAndGetUpdatedAsync();
        Task Synced(int id);
    }

    public class IdentityService : BaseService, IIdentityService
    {
        private readonly HttpRequestClient _client;
        private readonly IDbConnectionAccessor _db;
        private readonly IdealCrmSettings _options;
        private readonly IPersonService _person;
        private readonly ILogger<IdentityService> _logger;

        public IdentityService(HttpRequestClient client,
            IDbConnectionAccessor db,
            IOptions<IdealCrmSettings> options,
            IPersonService person,
            ILogger<IdentityService> logger)
        {
            _client = client;
            _db = db;
            _options = options.Value;
            _person = person;
            _logger = logger;
        }

        public async Task<bool> CheckMobileIsExistAsync(string mobile)
        {
            mobile = mobile.RemoveMobilePrefixNo();

            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var tran = connection.BeginTransaction())
                {
                    return await connection.QueryFirstOrDefaultAsync<bool>
                    (
                        $"select count(1) from dbo.CrmCompanyPersons where prsMobile like N'%{mobile}%';",
                        null,
                        tran
                    );
                }
            }
        }

        private async Task<int?> GetPresentationIdByAsync(string filter)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $"select top 1 p.companypresentationid from CrmCompanyPresentation as p where rtrim(ltrim(p.presentation)) = N'{filter}';";
                    return await connection.QueryFirstOrDefaultAsync<int?>(query, null, transaction);
                }
            }
        }

        private async Task<int?> GetCompanyTypeIdByAsync(string filter)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $"select top 1 t.CompanyTypeID from CrmCompanyType as t where ltrim(rtrim(t.CompanyTypeName)) = N'{filter}';";
                    return await connection.QueryFirstOrDefaultAsync<int?>(query, null, transaction, null, CommandType.Text);
                }
            }
        }

        private async Task<int?> GetCompanyGroupIdByAsync(string filter)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $"select top 1 g.companygroupid from CrmCompanyGroups as g where ltrim(rtrim(g.GroupName)) = N'{filter}';";
                    return await connection.QueryFirstOrDefaultAsync<int?>(query, null, transaction, null, CommandType.Text);
                }
            }
        }

        private async Task<int?> GetCountryIdByAsync(string filter)
        {
            if (String.IsNullOrWhiteSpace(filter)) return default;

            filter = filter.Trim('\'');

            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $"select top 1 c.countryid from country as c where rtrim(ltrim(c.country)) = N'{filter}';";
                    return await connection.QueryFirstOrDefaultAsync<int?>(query, null, transaction, null, CommandType.Text);
                }
            }
        }

        private async Task<int?> GetProvinceIdByAsync(string filter, int countryId)
        {
            if (String.IsNullOrWhiteSpace(filter)) return default;

            filter = filter.Trim('\'');

            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $@"select top 1 p.provinceid
                    from Province as p
                    where rtrim(ltrim(p.province)) = N'{filter.Trim()}'
                    and p.countryId = '{countryId}';";
                    return await connection.QueryFirstOrDefaultAsync<int?>(
                        query,
                        null,
                        transaction
                    );
                }
            }
        }

        private async Task<int?> GetCityIdByAsync(string filter, int provinceId)
        {
            if (String.IsNullOrWhiteSpace(filter)) return default;

            filter = filter.Trim('\'');

            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    var query = $@"select top 1 c.cityid
                    from City as c
                    where
                    rtrim(ltrim(c.city)) = N'{filter}' and c.provinceId = '{provinceId}';";
                    return await connection.QueryFirstOrDefaultAsync<int?>(
                        query,
                        null,
                        transaction
                    );
                }
            }
        }

        public async Task<IEnumerable<string>> GetCampaignIdsAsync(string[] names)
        {
            using (var connection = _db.CreateConnection())
            {
                connection.ConnectionString = _options.ConnectionString;
                await connection.OpenAsync();
                using (var tran = connection.BeginTransaction())
                {
                    var query = $"select c.companycampaignid from dbo.crmcompanycampaign as c where c.campaignname in (N'{String.Join("', N'", names)}');";
                    return await connection.QueryAsync<string>(query, null, tran);
                }
            }
        }

        /// <summary>
        /// این سرویس به صورت هوشمند بر اساس نام کاربری و شناسه کاربر در بانک اطلاعاتی
        /// ایده آل جستجو میکند و در صورت وجود کاربر شناسه آن را بر میگرداند
        /// </summary>
        /// <param name="user">نام کاربر یا شناسه</param>
        /// <returns>شناسه کاربر</returns>
        public async Task<int> GetUserIdAsync(string user)
        {
            if (String.IsNullOrWhiteSpace(user)) throw new ArgumentNullException("فیلد نام کاربری الزامی است و نمیتواند خالی رها شود.");

            using (var db = _db.CreateConnection())
            {
                db.ConnectionString = _options.ConnectionString;
                await db.OpenAsync();
                using (var tran = db.BeginTransaction())
                {
                    var query = $@"select top 1 u.userid
                    from users as u
                    where
                    u.username = N'{user}' or u.userid = '{user.ConvertTo<int>()}';";
                    return await db.QuerySingleAsync<int>(
                        query,
                        null,
                        tran
                    );
                }
            }
        }

        public async Task<CreateIdentityResponseInfo> CreateIdentityAsync(CreateOrganizationRequestInfo org,
            CreatePersonRequestInfo person)
        {
            person.Mobile = person.Mobile.RemoveMobilePrefixNo("0");

            if (string.IsNullOrWhiteSpace(person.Mobile) is false && person.Mobile.IsMobileNo() is false) throw new WorkflowException(
                "مقدار پارامتر شماره موبایل نامعتبر است.",
                null,
                person.Mobile,
                "رابط گرامی؛ شماره موبایل وارد شده نامعتبر می‌باشد. پیشنهاد میشود نسبت به اصلاح شماره موبایل اقدام نمایید سپس درخواست را مجدداً به صف همگام سازی ارسال کنید."
            );

            var mobileIsExist = await CheckMobileIsExistAsync(person.Mobile);

            if (mobileIsExist) throw new PersonIsExistException("شماره همراه تکراری است.");

            org.UserName = person.UserName = String.IsNullOrWhiteSpace(org.UserName) ? _options.UserName : org.UserName;
            org.Password = person.Password = String.IsNullOrWhiteSpace(org.Password) ? _options.Password : org.Password;
            // واکشی کشور
            org.Country = String.IsNullOrWhiteSpace(org.Country) ? _options.CountryId : org.Country;
            // واکشی استان
            org.Province = String.IsNullOrWhiteSpace(org.Province) ? _options.ProvinceId : org.Province;
            // واکشی شهر
            org.City = String.IsNullOrWhiteSpace(org.City) ? _options.CityId : org.City;
            // واکشی ایجاد توسط
            org.CreatorUser = person.CreatorUser = String.IsNullOrWhiteSpace(org.CreatorUser) ? _options.DefaultCreatorUser : org.CreatorUser;
            // Identity type is person or organization?
            org.IdentityType = org.IdentityType.Equals("حقیقی", StringComparison.InvariantCultureIgnoreCase) ? "1" : "0";
            // Fetch presentation ID
            var presentationId = await GetPresentationIdByAsync(org.Presentation);
            // Fetch company type ID
            var companyTypeId = await GetCompanyTypeIdByAsync(org.Type);
            // Fetch company group ID
            var groupId = await GetCompanyGroupIdByAsync(org.Group_1);
            // واکشی شناسه کشور
            var country = await GetCountryIdByAsync(org.Country);
            // واکشی شناسه استان
            var province = country.HasValue ? await GetProvinceIdByAsync(org.Province, country.Value) : default;
            // واکشی شناسه شهر
            var city = province.HasValue ? await GetCityIdByAsync(org.City, province.Value) : default;
            // واکشی شناسه کاربر ایجاد کننده مخاطب
            int? creatorUserIdOrg = org.CreatorUser.ConvertTo<int>();
            if (creatorUserIdOrg.HasValue is false && String.IsNullOrWhiteSpace(org.CreatorUser) is false)
            {
                creatorUserIdOrg = await GetUserIdAsync(org.CreatorUser);
            }
            // واکشی شناسه کاربر ایجاد کننده پرسنل
            int? creatorUserIdPerson = person.CreatorUser.ConvertTo<int>();
            if (creatorUserIdPerson.HasValue is false && String.IsNullOrWhiteSpace(person.CreatorUser) is false)
            {
                creatorUserIdPerson = await GetUserIdAsync(person.CreatorUser);
            }
            // واکشی شناسه کمپین(ها)
            string campaignIds = null;
            if (String.IsNullOrWhiteSpace(org.Campaign) == false)
            {
                campaignIds = String.Join(',', await GetCampaignIdsAsync(org.Campaign.Split(',', StringSplitOptions.RemoveEmptyEntries)));
            }
            // واکشی شناسه کاربر تخصیص یافته
            int? assignToId = org.AssignTo.ConvertTo<int>();
            if (assignToId.HasValue is false && String.IsNullOrWhiteSpace(org.AssignTo) is false)
            {
                assignToId = await GetUserIdAsync(org.AssignTo);
            }
            // Extract company's phone prefix
            var cmpPhonePrefix = String.IsNullOrWhiteSpace(org.Phone) ? "" : Regex.Replace(org.Phone, TELPHONE_REGEX_FORMAT, "");
            org.Phone = String.IsNullOrWhiteSpace(org.Phone) ? "" : Regex.Match(org.Phone, TELPHONE_REGEX_FORMAT).ToString();
            // Creating a organization identity profile
            var org_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/api/apicompany/insert",
                new
                {
                    UserName = org.UserName,
                    Password = org.Password,
                    ApiCmpName = org.Subject,
                    ApiCmpTypeId = companyTypeId,
                    ApiCmpCountryId = country,
                    ApiCmpProvinceId = province,
                    ApiCmpCityId = city,
                    ApiCmpDescription = org.Description,
                    ApiCmpAddress = org.Address,
                    ApiCmpPresentationId = presentationId,
                    ApiCmpGroupId = groupId,
                    ApiCmpNationalCode = org.NationalId,
                    ApiCmpEconomicCode = org.EconomicCode,
                    ApiCmpRegistrationNumber = org.RegisterNumber,
                    ApiCmpZipCode = org.PostalCode,
                    ApiCmpPostBox = org.PostalBox,
                    ApiCmpEmail = org.Email,
                    ApiCmpPreTel = cmpPhonePrefix,
                    ApiCmpTel = org.Phone,
                    ApiCmpReferUserId = assignToId,
                    UserId = creatorUserIdOrg,
                    ApiCmpCampaignIds = campaignIds
                }
            );

            // Check the service result
            if (org_response.Status == Status.Error)
            {
                // Throw exception if one of the information is duplicate or failed request
                if (org_response.Message.Contains("تکرار"))
                    throw new PersonIsExistException(org_response.Message);
                else
                    throw new NotImplementedException(org_response.Message);
            }

            // Apply the type of identity
            await _client.SendPostRequestAsync<BaseResultModel>($"{_options.ApiAddress}/api/apiCompany/update", new
            {
                UserName = org.UserName,
                Password = org.Password,
                ApiCompanyId = org_response.Data,
                ApiCmpKind = org.IdentityType,
                ApiCmpReferUserId = org.AssignTo.ConvertTo<int>(),
                UserId = creatorUserIdOrg
            });

            // Extract person's phone prefix
            var prsPhonePrefix = String.IsNullOrWhiteSpace(person.Phone) ? "" : Regex.Replace(person.Phone, TELPHONE_REGEX_FORMAT, "", RegexOptions.CultureInvariant);
            person.Phone = String.IsNullOrWhiteSpace(person.Phone) ? "" : Regex.Match(person.Phone, TELPHONE_REGEX_FORMAT, RegexOptions.CultureInvariant).ToString();

            // Creating a person identity profile
            var person_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/api/apicompanyperson/insert",
                new
                {
                    UserName = org.UserName,
                    Password = org.Password,
                    ApiPrsLName = person.LastName,
                    ApiPrsFName = person.FirstName,
                    ApiPrsMobile = person.Mobile,
                    ApiCompanyId = org_response.Data,
                    ApiPrsJobId = person.Job,
                    ApiPrsDepartmentId = person.Department,
                    ApiPrsEmail = person.Email,
                    ApiPrsNationalCode = person.NationalCode,
                    ApiPrsAddress = person.Address,
                    ApiPrsDescription = person.Description,
                    ApiPrsPreTel = prsPhonePrefix,
                    ApiPrsTel = person.Phone,
                    UserId = creatorUserIdPerson
                });

            if (person_response.Status == Status.Error) throw new NotImplementedException(person_response.Message);

            // Return successful information to the previous step
            return new CreateIdentityResponseInfo
            {
                OrganizationId = org_response.Data,
                PersonId = person_response.Data
            };
        }

        public async Task UpdateAsync(
            IdentitySearchKind searchKind,
            string userName,
            string password,
            string filter,
            bool isIdentityTypeEditable,
            string identityType,
            bool isSubjectEditable,
            string subject,
            bool isTypeEditable,
            string type,
            bool isCountryEditable,
            string country,
            bool isProvinceEditable,
            string province,
            bool isCityEditable,
            string city,
            bool isMobileEditable,
            string mobile,
            bool isFirstNameEditable,
            string firstName,
            bool isLastNameEditable,
            string lastName,
            bool isDescriptionEditable,
            string description,
            bool isAddressEditable,
            string address,
            bool isGroup_1Editable,
            string group_1,
            bool isPresentationEditable,
            string presentation,
            bool isNationalIdEditable,
            string nationalId,
            bool isEconomicCodeEditable,
            string economicCode,
            bool isRegisterNumberEditable,
            string registerNumber,
            bool isPostalCodeEditable,
            string postalCode,
            bool isPostalBoxEditable,
            string postalBox,
            bool isCmpEmailEditable,
            string cmpEmail,
            bool isCmpPhoneEditable,
            string cmpPhone,
            bool isJobEditable,
            string job,
            bool isDepartmentEditable,
            string department,
            bool isPrsEmailEditable,
            string prsEmail,
            bool isNationalCodeEditable,
            string nationalCode,
            bool isPrsAddressEditable,
            string prsAddress,
            bool isPrsDescriptionEditable,
            string prsDescription,
            bool isPrsPhoneEditable,
            string prsPhone,
            bool isAssignToEditable,
            string assignTo,
            bool isCampaignEditable,
            bool addToCampaign,
            string campaign)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            country = String.IsNullOrWhiteSpace(country) ? _options.CountryId : country;
            province = String.IsNullOrWhiteSpace(province) ? _options.ProvinceId : province;
            city = String.IsNullOrWhiteSpace(city) ? _options.CityId : city;

            identityType = identityType.Equals("حقیقی", StringComparison.InvariantCultureIgnoreCase) ? "1" : "0";

            // Get phone prefix
            var cmpPhonePrefix = String.IsNullOrWhiteSpace(cmpPhone) ? "" : Regex.Replace(cmpPhone, TELPHONE_REGEX_FORMAT, "", RegexOptions.CultureInvariant);
            cmpPhone = String.IsNullOrWhiteSpace(cmpPhone) ? "" : Regex.Match(cmpPhone, TELPHONE_REGEX_FORMAT, RegexOptions.CultureInvariant).ToString();

            var prsPhonePrefix = String.IsNullOrWhiteSpace(prsPhone) ? "" : Regex.Replace(prsPhone, TELPHONE_REGEX_FORMAT, "", RegexOptions.CultureInvariant);
            prsPhone = String.IsNullOrWhiteSpace(prsPhone) ? "" : Regex.Match(prsPhone, TELPHONE_REGEX_FORMAT, RegexOptions.CultureInvariant).ToString();

            // convert identitySearchKind to presonSearchKind
            var personSearchKind = searchKind switch
            {
                IdentitySearchKind.Id => PersonSearchKind.Id,
                IdentitySearchKind.Mobile => PersonSearchKind.Mobile,
                IdentitySearchKind.NationalCode => PersonSearchKind.NationalCode,
                IdentitySearchKind.Email => PersonSearchKind.Email,
                _ => throw new Exception(nameof(IdentitySearchKind)),
            };

            var personDetails = await _person.GetDetailsByAsync(userName, password, filter, personSearchKind);

            var companyData = new Dictionary<string, object>
            {
                { "UserName", userName },
                { "Password", password },
                { "ApiCompanyId", personDetails.ApiPrsCompanyId },
                { "UserId", personDetails.ApiUserId }
            };

            if (isSubjectEditable) companyData.Add("ApiCmpName", subject);
            if (isTypeEditable) companyData.Add("ApiCmpTypeId", await GetCompanyTypeIdByAsync(type));
            if (isGroup_1Editable) companyData.Add("ApiCmpGroupId", await GetCompanyGroupIdByAsync(group_1));
            if (isCountryEditable)
            {
                var countryId = await GetCountryIdByAsync(country);
                if (countryId.HasValue) companyData.Add("ApiCmpCountryId", countryId.Value);

                if (isProvinceEditable)
                {
                    var provinceId = countryId.HasValue ? await GetProvinceIdByAsync(province, countryId.Value) : default;
                    if (provinceId.HasValue) companyData.Add("ApiCmpProvinceId", provinceId.Value);

                    if (isCityEditable)
                    {
                        var cityId = provinceId.HasValue ? await GetCityIdByAsync(city, provinceId.Value) : default;
                        if (cityId.HasValue) companyData.Add("ApiCmpCityId", cityId.Value);
                    }
                }
            }
            if (isDescriptionEditable) companyData.Add("ApiCmpDescription", description);
            if (isAddressEditable) companyData.Add("ApiCmpAddress", address);
            if (isPresentationEditable) companyData.Add("ApiCmpPresentationId", await GetPresentationIdByAsync(presentation));
            if (isNationalIdEditable) companyData.Add("ApiCmpNationalCode", nationalId);
            if (isEconomicCodeEditable) companyData.Add("ApiCmpEconomicCode", economicCode);
            if (isRegisterNumberEditable) companyData.Add("ApiCmpRegistrationNumber", registerNumber);
            if (isPostalCodeEditable) companyData.Add("ApiCmpZipCode", postalCode);
            if (isCmpEmailEditable) companyData.Add("ApiCmpEmail", cmpEmail);
            if (isAssignToEditable) companyData.Add("ApiCmpReferUserId", await GetUserIdAsync(assignTo));
            if (isIdentityTypeEditable) companyData.Add("ApiCmpKind", identityType);
            if (isPostalBoxEditable) companyData.Add("ApiCmpPostBox", postalBox);

            if (isCmpPhoneEditable)
            {
                companyData.Add("ApiCmpPreTel", cmpPhonePrefix);
                companyData.Add("ApiCmpTel", cmpPhone);
            }

            if (isCampaignEditable)
            {
                IEnumerable<string> campaign_ids = null;

                if (String.IsNullOrWhiteSpace(campaign) is false)
                {
                    campaign_ids = await GetCampaignIdsAsync(campaign.Split(',', '،', StringSplitOptions.RemoveEmptyEntries));
                }

                if (addToCampaign)
                {
                    var identity = await GetDetailsByIdAsync(userName, password, personDetails.ApiPrsCompanyId);
                    var identity_campaign_ids = identity.ApiCmpCampaignIds?.Split(',');
                    if (identity_campaign_ids?.Any() ?? false)
                    {
                        campaign_ids = campaign_ids.Concat(identity_campaign_ids.ToArray());
                    }
                }

                companyData.Add("ApiCmpCampaignIds", campaign_ids is null ? null : String.Join(",", campaign_ids));
            }

            var org_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiCompany/Update",
                companyData
            );

            if (org_response.Status != Status.Success) throw new WorkflowException(
                org_response.Message,
                null,
                JsonConvert.SerializeObject(companyData)
            );

            var prsData = new Dictionary<string, object>()
            {
                {"UserName", userName},
                {"Password", password},
                {"ApiCompanyId", personDetails.ApiPrsCompanyId},
                {"ApiCompanyPersonId", personDetails.ApiCompanyPersonID},
                {"UserId", personDetails.ApiUserId}
            };

            if (isMobileEditable) prsData.Add("ApiPrsMobile", Regex.Replace(mobile, MOBILE_REGEX_FORMAT, "0", RegexOptions.CultureInvariant));
            if (isFirstNameEditable) prsData.Add("ApiPrsFName", firstName);
            if (isLastNameEditable) prsData.Add("ApiPrsLName", lastName);
            if (isJobEditable) prsData.Add("ApiPrsJobId", job);
            if (isDepartmentEditable) prsData.Add("ApiPrsDepartmentId", department);
            if (isPrsEmailEditable) prsData.Add("ApiPrsEmail", prsEmail);
            if (isNationalCodeEditable) prsData.Add("ApiPrsNationalCode", nationalCode);
            if (isPrsAddressEditable) prsData.Add("ApiPrsAddress", prsAddress);
            if (isPrsDescriptionEditable) prsData.Add("ApiPrsDescription", prsDescription);
            if (isPrsPhoneEditable)
            {
                prsData.Add("ApiPrsPreTel", prsPhonePrefix);
                prsData.Add("ApiPrsTel", prsPhone);
            }

            var prs_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiCompanyPerson/Update",
                prsData
            );

            if (prs_response.Status != Status.Success)
            {
                throw new NotImplementedException(prs_response.Message);
            }
        }

        private async Task<IdentityInfo> GetDetailsByIdAsync(string userName, string password, string id)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;

            var data = new
            {
                UserName = userName,
                Password = password,
                ApiCompanyId = id,
            };

            var response = await _client.SendPostRequestAsync<BaseInformationResultModel<IdentityInfo>>(
                $"{_options.ApiAddress}/Api/ApiCompany/Select",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            return response.Data.Single();
        }

        public async Task<IList<IdentityResponseInfo>> SyncAndGetUpdatedAsync()
        {
            if (!ConnectionIsValid) return new List<IdentityResponseInfo>();

            DbConnection db = null;
            DbTransaction tran = null;

            try
            {
                db = _db.CreateConnection();
                db.ConnectionString = _options.ConnectionString;
                await db.OpenAsync();
                tran = db.BeginTransaction();

                var identities = await db.QueryAsync<IdentityResponseInfo>(
                    $@"select top {_options.NumberOfEventsPerRequest} *
                    from
                    [summary.integration].ideal.[Identity] as i
                    where
                    i.sync = 0;",
                    null,
                    tran
                );

                if (identities.Any()) return identities.ToList();

                await db.ExecuteAsync(GetCUIdentityQuery(), null, tran);
                await tran.CommitAsync();
                return new List<IdentityResponseInfo>();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new List<IdentityResponseInfo>();
            }
            finally
            {
                tran?.Dispose();
                db?.Dispose();
            }
        }

        private string GetCUIdentityQuery()
        {
            return
            @"declare @identity table(
                Id int not null,
                Subject nvarchar(512) not null,
                Number nvarchar(512),
                IdentityType nvarchar(32) null,
                mobile nvarchar(32),
                Sync bit,
                LastModify datetime
            );

            with company_temp_person as
            (
                select
                    row_number() over(partition by p.prscompanyid order by p.prscompanyid asc) as row_index,
                    *
                from
                    crmideal.dbo.CrmCompanyPersons as p
            )
            insert into @identity(id, subject, number, identitytype, mobile, sync, lastmodify)
            select
            c.CompanyId,
            c.cmpName as Name,
            c.cmpNumber as Number,
            c.cmpTypeId as IdentityType,
            p.prsMobile,
            0 as Sync,
            getdate()
            from
            crmideal.dbo.crmcompany as c
            inner join company_temp_person as p on c.companyid = p.prsCompanyId and p.Row_Index = 1;

            insert into [summary.integration].ideal.[identity](id, subject, number, identitytype, mobile, sync, lastmodify)
            select
            i.id,
            i.subject,
            i.number,
            i.identitytype,
            i.mobile,
            0,
            getdate()
            from
            @identity as i
            left join [summary.integration].ideal.[identity] as ii on i.id = ii.id
            where
            ii.id is null;

            update
            ii
            set
            ii.subject = i.subject,
            ii.number = i.number,
            ii.identitytype = i.identitytype,
            ii.mobile = i.mobile,
            ii.sync = 0,
            ii.lastmodify = getdate()
            from
            @identity as i
            inner join [summary.integration].ideal.[identity] as ii on i.id = ii.id
            where
            ii.subject <> i.subject or
            ii.number <> i.number or
            isnull(ii.identitytype, '') <> isnull(i.identitytype, '') or
            isnull(ii.mobile, '') <> isnull(i.mobile, '');";
        }

        public async Task Synced(int id)
        {
            using (var db = _db.CreateConnection())
            {
                db.ConnectionString = _options.ConnectionString;
                await db.OpenAsync();
                using (var tran = db.BeginTransaction())
                {
                    var query = @$"update
                    i
                    set
                    i.sync = 1
                    from
                    [summary.integration].ideal.[identity] as i where i.id = '{id}';";

                    await db.QueryAsync(
                        query,
                        null,
                        tran
                    );

                    await tran.CommitAsync();
                }
            }
        }

        private bool ConnectionIsValid
        {
            get => String.IsNullOrWhiteSpace(_options.ConnectionString) is false &&
                _options.AllowToRunCUIdentityEvent &&
                _options.NumberOfEventsPerRequest > 0;
        }
    }
}