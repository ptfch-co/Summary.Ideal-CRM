namespace Summary.IdealCrm.Workflows.Task.Project.Create
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
    using System.Threading.Tasks;

    public class CreateProjectInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<CreateProjectInIdealCrmTask> T;
        private readonly ILogger<CreateProjectInIdealCrmTask> _logger;
        private readonly IProjectService _project;

        public CreateProjectInIdealCrmTask(IStringLocalizer<CreateProjectInIdealCrmTask> t,
            ILogger<CreateProjectInIdealCrmTask> logger,
            IProjectService project)
        {
            T = t;
            _logger = logger;
            _project = project;
        }

        public override string Name => nameof(CreateProjectInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfCreateProject];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done]);
        }

        public string CompanyId
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public string Title
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> InquiryNumber
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Desc
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> StartDate
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> StarterUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Grade
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Priority
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Group
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CnvsStatusGroup
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PostFix
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> RemindDateTime
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IsTicket
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CmpPresentation
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IsFinished
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Campaign
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CreatorUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
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
            var companyId = workflowContext.GetInputOrDefault(CompanyId);
            var title = workflowContext.GetInputOrDefault(Title);
            var inquiryNumber = workflowContext.GetInputOrDefault(InquiryNumber.Expression);
            var desc = workflowContext.GetInputOrDefault(Desc.Expression);
            var startDate = workflowContext.GetInputOrDefault(StartDate.Expression).ConvertTo<DateTime>();
            var starterUser = workflowContext.GetInputOrDefault(StarterUser.Expression);
            var grade = workflowContext.GetInputOrDefault(Grade.Expression);
            var priority = workflowContext.GetInputOrDefault(Priority.Expression);
            var group = workflowContext.GetInputOrDefault(Group.Expression);
            var cnvsStatusGroup = workflowContext.GetInputOrDefault(CnvsStatusGroup.Expression);
            var postFix = workflowContext.GetInputOrDefault(PostFix.Expression);
            var remindDateTime = workflowContext.GetInputOrDefault(RemindDateTime.Expression).ConvertTo<DateTime>();
            var isTicket = workflowContext.GetInputOrDefault(IsTicket.Expression).ToBoolean();
            var cmpPresentation = workflowContext.GetInputOrDefault(CmpPresentation.Expression);
            var isFinished = workflowContext.GetInputOrDefault(IsFinished.Expression).ToBoolean();
            var campaign = workflowContext.GetInputOrDefault(Campaign.Expression);
            var creatorUser = workflowContext.GetInputOrDefault(CreatorUser.Expression);

            var prjId = await _project.CreateAsync(
                userName,
                password,
                companyId,
                title,
                inquiryNumber,
                desc,
                startDate,
                starterUser,
                grade,
                priority,
                group,
                cnvsStatusGroup,
                postFix,
                remindDateTime,
                isTicket,
                cmpPresentation,
                isFinished,
                campaign,
                creatorUser
            );

            workflowContext.Input[$"{Output}.Id"] = prjId;

            return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}