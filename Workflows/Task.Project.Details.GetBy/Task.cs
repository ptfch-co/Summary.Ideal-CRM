namespace Summary.IdealCrm.Workflows.Task.Project.Details.GetBy
{
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetProjectDetailsByInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<GetProjectDetailsByInIdealCrmTask> T;
        private readonly ILogger<GetProjectDetailsByInIdealCrmTask> _logger;
        private readonly IProjectService _project;

        public GetProjectDetailsByInIdealCrmTask(IStringLocalizer<GetProjectDetailsByInIdealCrmTask> t,
            ILogger<GetProjectDetailsByInIdealCrmTask> logger,
            IProjectService project)
        {
            T = t;
            _logger = logger;
            _project = project;
        }

        public override string Name => nameof(GetProjectDetailsByInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfGetProjectDetailsBy];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done],
                T[IdealCrm.Workflows.NotExist],
                T[IdealCrm.Workflows.Iterate]);
        }

        public string Filter
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public ProjectSearchKind SearchKind
        {
            get => GetProperty(() => ProjectSearchKind.Id);
            set => SetProperty(value);
        }

        public string Output
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public int Index
        {
            get => GetProperty(() => 0);
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {

            var userName = workflowContext.GetInputOrDefault(UserName.Expression);
            var password = workflowContext.GetInputOrDefault(Password.Expression);
            var filter = workflowContext.GetInputOrDefault(Filter);

            IList<ProjectInfo> projects = await _project.GetProjectsByAsync(
                userName,
                password,
                filter,
                SearchKind
            );

            if (projects.Any() is false) return Outcomes(IdealCrm.Workflows.NotExist);

            if (SearchKind is ProjectSearchKind.IdentityId && Index == projects.Count)
                return Outcomes(IdealCrm.Workflows.Done);

            var details = projects[Index];

            workflowContext.Input[$"{Output}.Id"] = details.ApiProjectID;
            workflowContext.Input[$"{Output}.Company.Id"] = details.ApiPrjCompanyId;
            workflowContext.Input[$"{Output}.Company.Name"] = details.ApiPrjCompany;
            workflowContext.Input[$"{Output}.Title"] = details.ApiPrjTitle;
            workflowContext.Input[$"{Output}.Fix"] = details.ApiPrjPostFix;
            workflowContext.Input[$"{Output}.Description"] = details.ApiPrjDesc;
            workflowContext.Input[$"{Output}.StartDateTime"] = details.ApiPrjStartDateTime;
            workflowContext.Input[$"{Output}.Grade.Id"] = details.ApiPrjGradeId;
            workflowContext.Input[$"{Output}.Grade.Name"] = details.ApiPrjGrade;
            workflowContext.Input[$"{Output}.Priority.Id"] = details.ApiPrjPriorityId;
            workflowContext.Input[$"{Output}.Priority.Name"] = details.ApiPrjPriority;
            workflowContext.Input[$"{Output}.Group.Id"] = details.ApiPrjGroupId;
            workflowContext.Input[$"{Output}.Group.Name"] = details.ApiPrjGroup;
            workflowContext.Input[$"{Output}.ProgressModel.Id"] = details.ApiPrjcnvsStatusGroupId;
            workflowContext.Input[$"{Output}.ProgressModel.Name"] = details.ApiPrjcnvsStatusGroup;
            workflowContext.Input[$"{Output}.Presentation.Id"] = details.ApiPrjCmpPresentationId;
            workflowContext.Input[$"{Output}.Presentation.Name"] = details.ApiPrjCmpPresentation;
            workflowContext.Input[$"{Output}.Archive"] = details.ApiPrjIsFinished ?? false;
            workflowContext.Input[$"{Output}.Archive.DateTime"] = details.ApiPrjFinishedDateTime;

            if (SearchKind is ProjectSearchKind.IdentityId)
            {
                Index++;
                return Outcomes(IdealCrm.Workflows.Iterate);
            }
            else
                return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}