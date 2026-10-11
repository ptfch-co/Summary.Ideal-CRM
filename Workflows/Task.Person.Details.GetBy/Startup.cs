namespace Summary.IdealCrm.Workflows.Task.Person.Details.GetBy
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.GetPersonDetailsBy)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<GetPersonDetailsByInIdealCrmTask, GetPersonDetailsByInIdealCrmTaskDisplay>();
        }
    }
}