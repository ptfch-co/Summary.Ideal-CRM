namespace Summary.IdealCrm.Workflows.Task.Project.Details.GetBy
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.GetProjectDetailsBy)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<GetProjectDetailsByInIdealCrmTask, GetProjectDetailsByInIdealCrmTaskDisplay>();
        }
    }
}