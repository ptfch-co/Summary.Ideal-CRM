namespace Summary.IdealCrm.Workflows.Task.CreateIdentity
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.CreateIdentity)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<CreateIdentityInIdealCrmTask, CreateIdentityInIdealCrmTaskDisplay>();
        }
    }
}