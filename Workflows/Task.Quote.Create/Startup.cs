namespace Summary.IdealCrm.Workflows.Task.Quote.Create
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.Modules;
    using Core.Workflows.Helpers;

    [Feature(IdealCrm.Features.CreateQuote)]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddActivity<CreateQuoteInIdealCrmTask, CreateQuoteInIdealCrmTaskDisplay>();
        }
    }
}