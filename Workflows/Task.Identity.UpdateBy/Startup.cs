namespace Summary.IdealCrm.Workflows.Task.Identity.UpdateBy
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.UpdateIdentityBy)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<UpdateIdentityByInIdealCrmTask, UpdateIdentityByInIdealCrmTaskDisplay>();
        }
    }
}