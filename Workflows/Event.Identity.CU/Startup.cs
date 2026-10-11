namespace Summary.IdealCrm.Workflows.Event.Identity.CU
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.BackgroundTasks;
    using Core.Modules;
    using Core.Workflows.Helpers;
    using Timer;

    [Feature(Ideal.Features.CUIdentityEvent)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<IdealCUIdentityEvent, IdealCUIdentityEventDisplay>();
            services.AddSingleton<IBackgroundTask, CUIdentityTimerBackground>();
        }
    }
}