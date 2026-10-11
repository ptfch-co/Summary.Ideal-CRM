using Core.Workflows;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using Summary.IdealCrm.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Summary.IdealCrm.Services
{
    public interface IUserService
    {
        Task<int> GetUserIdAsync(string user);
    }

    public class UserService : IUserService
    {
        private readonly HttpRequestClient _client;
        private readonly IdealCrmSettings _options;

        public UserService(HttpRequestClient client,
            IOptions<IdealCrmSettings> options)
        {
            _client = client;
            _options = options.Value;
        }

        public async Task<int> GetUserIdAsync(string username)
        {
            var data = new
            {
                UserName = _options.UserName,
                Password = _options.Password,
                ApiUserName = username
            };

            var user = await _client.SendPostRequestAsync<BaseInformationResultModel<UserInfo>>(
                $"{_options.ApiAddress}/Api/ApiUser/Select",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            return user.Data.Single().ApiUserId;
        }
    }
}