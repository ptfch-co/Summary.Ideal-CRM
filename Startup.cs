namespace Summary.IdealCrm
{
    using Core.Workflows.Helpers;
    using Core.DisplayManagement.Handlers;
    using Core.Modules;
    using Core.Navigation;
    using Core.Security.Permissions;
    using Core.Settings;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Summary.IdealCrm.Services;
    using Summary.IdealCrm.Settings;
    using Summary.IdealCrm.Workflows.Task.Conversation.Create;
    using Summary.IdealCrm.Workflows.Task.MobileIsExist;
    using Summary.IdealCrm.Workflows.Task.Project.Create;
    using Summary.IdealCrm.Workflows.Task.Quote.Create;

    [Feature(IdealCrm.Features.IdealCrm)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IConversationService, ConversationService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<INavigationProvider, Menu>();
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDisplayDriver<ISite>, IdealCrmSettingsDisplayDriver>();

            services.AddTransient<IConfigureOptions<IdealCrmSettings>, IdealCrmSettingsConfiguration>();

            services.AddActivity<CheckMobileIsExistInIdealCrmTask, CheckMobileIsExistInIdealCrmTaskDisplay>();
            services.AddActivity<CreateProjectInIdealCrmTask, CreateProjectInIdealCrmTaskDisplay>();
            services.AddActivity<CreateConversationInIdealCrmTask, CreateConversationInIdealCrmTaskDisplay>();
            services.AddActivity<CreateQuoteInIdealCrmTask, CreateQuoteInIdealCrmTaskDisplay>();
        }
    }
}