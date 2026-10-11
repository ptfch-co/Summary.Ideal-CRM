namespace Summary.IdealCrm.Settings
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Core.DisplayManagement.Entities;
    using Core.DisplayManagement.Handlers;
    using Core.DisplayManagement.Views;
    using Core.Entities;
    using Core.Environment.Shell;
    using Core.Settings;

    public class IdealCrmSettings
    {
        public string ApiAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; set; }
        public string CountryId { get; set; }
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public string DefaultCreatorUser { get; set; }
        public int NumberOfEventsPerRequest { get; set; }
        public bool AllowToRunCUIdentityEvent { get; set; }
    }

    public class IdealCrmSettingsDisplayDriver : SectionDisplayDriver<ISite,
        IdealCrmSettings>
    {
        private readonly IShellHost _host;
        private readonly ShellSettings _shell;
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly IAuthorizationService _authorize;

        public IdealCrmSettingsDisplayDriver(IShellHost host,
            ShellSettings settings,
            IHttpContextAccessor httpContext,
            IAuthorizationService authorize)
        {
            _host = host;
            _shell = settings;
            _httpAccessor = httpContext;
            _authorize = authorize;
        }

        public override async Task<IDisplayResult> EditAsync(IdealCrmSettings settings,
            BuildEditorContext context)
        {
            var user = _httpAccessor.HttpContext?.User;
            if (user is null || !await _authorize.AuthorizeAsync(user, Permissions.ManageIdealCrmSettings))
            {
                return null;
            }

            var init = Initialize<IdealCrmSettings>("IdealCrmSettings_Edit", model =>
            {
                model.ApiAddress = settings.ApiAddress;
                model.UserName = settings.UserName;
                model.Password = settings.Password;
                model.ConnectionString = settings.ConnectionString;
                model.CountryId = settings.CountryId;
                model.ProvinceId = settings.ProvinceId;
                model.CityId = settings.CityId;
                model.DefaultCreatorUser = settings.DefaultCreatorUser;
                model.AllowToRunCUIdentityEvent = settings.AllowToRunCUIdentityEvent;
                model.NumberOfEventsPerRequest = settings.NumberOfEventsPerRequest;
            });
            return init.Location("Content:5").OnGroup("IdealCrm");
        }

        public override async Task<IDisplayResult> UpdateAsync(IdealCrmSettings settings,
            BuildEditorContext context)
        {
            var user = _httpAccessor.HttpContext?.User;
            if (user is null || !await _authorize.AuthorizeAsync(user, Permissions.ManageIdealCrmSettings))
            {
                return null;
            }
            if (context.GroupId == "IdealCrm")
            {
                await context.Updater.TryUpdateModelAsync(settings, Prefix);
                await _host.ReloadShellContextAsync(_shell);
            }
            return await EditAsync(settings, context);
        }
    }

    public class IdealCrmSettingsConfiguration : IConfigureOptions<IdealCrmSettings>
    {
        private readonly ISiteService _site;
        private readonly ILogger<IdealCrmSettingsConfiguration> _logger;

        public IdealCrmSettingsConfiguration(ISiteService site,
            ILogger<IdealCrmSettingsConfiguration> logger)
        {
            _site = site;
            _logger = logger;
        }

        public void Configure(IdealCrmSettings options)
        {
            var settings = _site.GetSiteSettingsAsync().GetAwaiter().GetResult().As<IdealCrmSettings>();
            options.ApiAddress = settings.ApiAddress;
            options.UserName = settings.UserName;
            options.Password = settings.Password;
            options.ConnectionString = settings.ConnectionString;
            options.CountryId = settings.CountryId;
            options.ProvinceId = settings.ProvinceId;
            options.CityId = settings.CityId;
            options.DefaultCreatorUser = settings.DefaultCreatorUser;
            options.AllowToRunCUIdentityEvent = settings.AllowToRunCUIdentityEvent;
            options.NumberOfEventsPerRequest = settings.NumberOfEventsPerRequest;
        }
    }
}