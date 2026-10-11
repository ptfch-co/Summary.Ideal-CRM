namespace Summary.IdealCrm.Workflows.Event.Identity.CU
{
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Core.Mvc.Utilities;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System.Collections.Generic;

    public class IdealCUIdentityEvent : EventActivity
    {
        private readonly IStringLocalizer<IdealCUIdentityEvent> T;
        private readonly ILogger<IdealCUIdentityEvent> _logger;
        private readonly IIdentityService _Identity;

        public IdealCUIdentityEvent(IStringLocalizer<IdealCUIdentityEvent> t,
            ILogger<IdealCUIdentityEvent> logger,
            IIdentityService Identity)
        {
            T = t;
            _logger = logger;
            _Identity = Identity;
        }

        public override string Name => nameof(IdealCUIdentityEvent);

        public override LocalizedString DisplayText => T[Ideal.Localize.SubjectOfCUIdentityEvent];

        public override LocalizedString Category => T[Ideal.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[Ideal.Workflows.Done]);
        }

        public override bool CanExecute(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return workflowContext.Input.ContainsKey("Ideal.Identity.Id")
                && workflowContext.Input["Ideal.Identity.Id"].ConvertTo<int>().HasValue;
        }

        public override ActivityExecutionResult Resume(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var id = workflowContext.Input["Ideal.Identity.Id"].ConvertTo<int>().Value;
            _Identity.Synced(id);
            return Outcomes(Ideal.Workflows.Done);
        }
    }
}