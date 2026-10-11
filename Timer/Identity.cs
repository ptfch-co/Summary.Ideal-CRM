namespace Summary.IdealCrm.Timer
{
    using Microsoft.Extensions.DependencyInjection;
    using Core.BackgroundTasks;
    using Core.Workflows.Services;
    using Services;
    using Summary.IdealCrm.Workflows.Event.Identity.CU;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    [BackgroundTask(Schedule = "*/30 * * * * *")]
    public class CUIdentityTimerBackground : BaseService, IBackgroundTask
    {
        public async Task DoWorkAsync(IServiceProvider serviceProvider,
            CancellationToken cancellationToken)
        {
            var iidentity = serviceProvider.GetRequiredService<IIdentityService>();
            var identities = await iidentity.SyncAndGetUpdatedAsync();

            if (identities.Any() is false) return;

            var workflow = serviceProvider.GetRequiredService<IWorkflowManager>();

            foreach (var identity in identities)
            {
                await workflow.TriggerEventAsync(nameof(IdealCUIdentityEvent), new Dictionary<string, object>
                {
                    { "Ideal.Identity.Id", identity.Id },
                    { "Ideal.Identity.Subject", identity.Subject },
                    { "Ideal.Identity.Number", identity.Number },
                    { "Ideal.Identity.Mobile", identity.Mobile },
                    { "Ideal.Identity.Mobile.With.Country.Prefix", String.IsNullOrWhiteSpace(identity.Mobile) ? null : $"+98{Regex.Replace(identity.Mobile, MOBILE_REGEX_FORMAT, String.Empty)}" },
                    { "Ideal.Identity.Type", identity.IdentityType },
                    { "Ideal.Identity.LastModify", identity.LastModify }
                });
            }
        }
    }
}