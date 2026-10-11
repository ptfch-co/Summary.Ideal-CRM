namespace Summary.IdealCrm.Workflows.Task.MobileIsExist
{
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Core.Mvc.Utilities;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class CheckMobileIsExistInIdealCrmTask : TaskActivity
    {
        private readonly IStringLocalizer<CheckMobileIsExistInIdealCrmTask> T;
        private readonly ILogger<CheckMobileIsExistInIdealCrmTask> _logger;
        private readonly IIdentityService _identity;

        public CheckMobileIsExistInIdealCrmTask(IStringLocalizer<CheckMobileIsExistInIdealCrmTask> t,
            ILogger<CheckMobileIsExistInIdealCrmTask> logger,
            IIdentityService identity)
        {
            T = t;
            _logger = logger;
            _identity = identity;
        }

        public override string Name => nameof(CheckMobileIsExistInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfCheckMobileIsExist];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(
                T[IdealCrm.Workflows.Exist],
                T[IdealCrm.Workflows.NotExist]
            );
        }

        public string Mobile
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var mobile = workflowContext.GetInputOrDefault(Mobile);

            return Outcomes(await _identity.CheckMobileIsExistAsync(mobile)
                ? IdealCrm.Workflows.Exist
                : IdealCrm.Workflows.NotExist
            );
        }
    }
}