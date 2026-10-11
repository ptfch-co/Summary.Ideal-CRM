namespace Summary.IdealCrm.Workflows.Task.MobileIsExist
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.CheckMobileIsExist)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<CheckMobileIsExistInIdealCrmTask, CheckMobileIsExistInIdealCrmTaskDisplay>();
        }
    }
}