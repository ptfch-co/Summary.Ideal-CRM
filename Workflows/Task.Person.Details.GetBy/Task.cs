namespace Summary.IdealCrm.Workflows.Task.Person.Details.GetBy
{
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GetPersonDetailsByInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<GetPersonDetailsByInIdealCrmTask> T;
        private readonly ILogger<GetPersonDetailsByInIdealCrmTask> _logger;
        private readonly IPersonService _person;

        public GetPersonDetailsByInIdealCrmTask(IStringLocalizer<GetPersonDetailsByInIdealCrmTask> t,
            ILogger<GetPersonDetailsByInIdealCrmTask> logger,
            IPersonService person)
        {
            T = t;
            _logger = logger;
            _person = person;
        }

        public override string Name => nameof(GetPersonDetailsByInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfGetPersonDetailsBy];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done],
                T[IdealCrm.Workflows.NotExist]);
        }

        public string Filter
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public PersonSearchKind SearchKind
        {
            get => GetProperty(() => PersonSearchKind.Mobile);
            set => SetProperty(value);
        }

        public string Output
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var userName = workflowContext.GetInputOrDefault(UserName.Expression);
            var password = workflowContext.GetInputOrDefault(Password.Expression);
            var filter = workflowContext.GetInputOrDefault(Filter);

            var details = await _person.GetDetailsByAsync(
                userName: userName,
                password: password,
                filter: filter,
                searchKind: SearchKind
            );

            if (details is null) return Outcomes(IdealCrm.Workflows.NotExist);

            workflowContext.Input[$"{Output}.Person.Id"] = details.ApiCompanyPersonID;
            workflowContext.Input[$"{Output}.Organization.Id"] = details.ApiPrsCompanyId;
            workflowContext.Input[$"{Output}.Organization.Name"] = details.ApiPrsCompany;
            workflowContext.Input[$"{Output}.LastName"] = details.ApiPrsLName;
            workflowContext.Input[$"{Output}.FirstName"] = details.ApiPrsFName;
            workflowContext.Input[$"{Output}.FullName"] = details.ApiPersonName;
            workflowContext.Input[$"{Output}.Job.Id"] = details.ApiPrsJobId;
            workflowContext.Input[$"{Output}.Job.Name"] = details.ApiPrsJob;
            workflowContext.Input[$"{Output}.Type.Id"] = details.ApiPrsTypeId;
            workflowContext.Input[$"{Output}.Type.Name"] = details.ApiPrsType;
            workflowContext.Input[$"{Output}.Group.Id"] = details.ApiPrsGroupId;
            workflowContext.Input[$"{Output}.Group.Name"] = details.ApiPrsGroup;
            workflowContext.Input[$"{Output}.Mobile"] = details.ApiPrsMobile;
            workflowContext.Input[$"{Output}.Email"] = details.ApiPrsEmail;
            workflowContext.Input[$"{Output}.Country.Id"] = details.ApiPrsCountryId;
            workflowContext.Input[$"{Output}.Country.Name"] = details.ApiPrsCountry;
            workflowContext.Input[$"{Output}.Province.Id"] = details.ApiPrsProvinceId;
            workflowContext.Input[$"{Output}.Province.Name"] = details.ApiPrsProvince;
            workflowContext.Input[$"{Output}.City.Id"] = details.ApiPrsCityId;
            workflowContext.Input[$"{Output}.City.Name"] = details.ApiPrsCity;
            workflowContext.Input[$"{Output}.Description"] = details.ApiPrsDescription;
            workflowContext.Input[$"{Output}.Address"] = details.ApiPrsAddress;

            return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}