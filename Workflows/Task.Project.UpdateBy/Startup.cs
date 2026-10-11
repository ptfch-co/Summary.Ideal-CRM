namespace Summary.IdealCrm.Workflows.Task.Project.UpdateBy
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.UpdateProjectBy)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<UpdateProjectByInIdealCrmTask, UpdateProjectByInIdealCrmTaskDisplay>();
        }
    }
}