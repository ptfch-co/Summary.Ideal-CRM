namespace Summary.IdealCrm.Workflows.Task.Project.UpdateBy
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

    public class UpdateProjectByInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<UpdateProjectByInIdealCrmTask> T;
        private readonly ILogger<UpdateProjectByInIdealCrmTask> _logger;
        private readonly IProjectService _project;

        public UpdateProjectByInIdealCrmTask(IStringLocalizer<UpdateProjectByInIdealCrmTask> t,
            ILogger<UpdateProjectByInIdealCrmTask> logger,
            IProjectService project)
        {
            T = t;
            _logger = logger;
            _project = project;
        }

        public override string Name => nameof(UpdateProjectByInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfUpdateProjectBy];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done]);
        }

        public string Filter
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Title
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool TitleEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Desc
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool DescEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> StartDate
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool StartDateEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> StarterUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool StarterUserEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Grade
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool GradeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Priority
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool PriorityEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Group
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool GroupEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CnvsStatusGroup
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool ConvStatusGroupEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PostFix
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool PostFixEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> RemindDateTime
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool RemindDateTimeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CmpPresentation
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool CmpPresentationEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IsFinished
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsFinishedEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var userName = workflowContext.GetInputOrDefault(UserName.Expression);
            var password = workflowContext.GetInputOrDefault(Password.Expression);
            var filter = workflowContext.GetInputOrDefault(Filter);
            var title = workflowContext.GetInputOrDefault(Title.Expression);
            var desc = workflowContext.GetInputOrDefault(Desc.Expression);
            var startDate = workflowContext.GetInputOrDefault(StartDate.Expression).ConvertTo<DateTime>();
            var starterUser = workflowContext.GetInputOrDefault(StarterUser.Expression);
            var grade = workflowContext.GetInputOrDefault(Grade.Expression);
            var priority = workflowContext.GetInputOrDefault(Priority.Expression);
            var group = workflowContext.GetInputOrDefault(Group.Expression);
            var cnvsStatusGroup = workflowContext.GetInputOrDefault(CnvsStatusGroup.Expression);
            var postFix = workflowContext.GetInputOrDefault(PostFix.Expression);
            var remindDateTime = workflowContext.GetInputOrDefault(RemindDateTime.Expression).ConvertTo<DateTime>();
            var cmpPresentation = workflowContext.GetInputOrDefault(CmpPresentation.Expression);
            var isFinished = workflowContext.GetInputOrDefault(IsFinished.Expression).ToBoolean();

            await _project.UpdateAsync(
                userName,
                password,
                filter,
                title,
                TitleEditable,
                desc,
                DescEditable,
                startDate,
                StartDateEditable,
                starterUser,
                StarterUserEditable,
                grade,
                GradeEditable,
                priority,
                PriorityEditable,
                group,
                GroupEditable,
                cnvsStatusGroup,
                ConvStatusGroupEditable,
                postFix,
                PostFixEditable,
                remindDateTime,
                RemindDateTimeEditable,
                cmpPresentation,
                CmpPresentationEditable,
                isFinished,
                IsFinishedEditable
             );

            return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}