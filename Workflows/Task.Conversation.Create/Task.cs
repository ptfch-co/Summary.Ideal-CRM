namespace Summary.IdealCrm.Workflows.Task.Conversation.Create
{
    using Microsoft.Extensions.Localization;
    using Core.Mvc.Utilities;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreateConversationInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<CreateConversationInIdealCrmTask> T;
        private readonly IConversationService _conversation;

        public CreateConversationInIdealCrmTask(IStringLocalizer<CreateConversationInIdealCrmTask> t,
            IConversationService conversation)
        {
            T = t;
            _conversation = conversation;
        }

        public override string Name => nameof(CreateConversationInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfCreateConversation];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done]);
        }

        public WorkflowExpression<string> CompanyId
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PersonId
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> ProjectId
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Date
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Type
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Desc
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CreatorUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> ReferUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Status
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Priority
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> RemindDate
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> AlarmDate
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> RemindTime
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IsRemind
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IsBookMark
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> DoingTime
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
            var companyId = workflowContext.GetInputOrDefault(CompanyId.Expression);
            var personId = workflowContext.GetInputOrDefault(PersonId.Expression);
            var projectId = workflowContext.GetInputOrDefault(ProjectId.Expression);
            var date = workflowContext.GetInputOrDefault(Date.Expression).ConvertTo<DateTime>();
            var type = workflowContext.GetInputOrDefault(Type.Expression);
            var desc = workflowContext.GetInputOrDefault(Desc.Expression);
            var creatorUser = workflowContext.GetInputOrDefault(CreatorUser.Expression);
            var referUser = workflowContext.GetInputOrDefault(ReferUser.Expression);
            var status = workflowContext.GetInputOrDefault(Status.Expression);
            var priority = workflowContext.GetInputOrDefault(Priority.Expression);
            var remindDate = workflowContext.GetInputOrDefault(RemindDate.Expression).ConvertTo<DateTime>();
            var alarmDate = workflowContext.GetInputOrDefault(AlarmDate.Expression).ConvertTo<DateTime>();
            var remindTime = workflowContext.GetInputOrDefault(RemindTime.Expression);
            var isRemind = workflowContext.GetInputOrDefault(IsRemind.Expression).ToBoolean();
            var isBookMark = workflowContext.GetInputOrDefault(IsBookMark.Expression).ToBoolean();
            var doingTime = workflowContext.GetInputOrDefault(DoingTime.Expression);

            var conversationId = await _conversation.CreateAsync(
                userName,
                password,
                companyId,
                personId,
                projectId,
                date,
                type,
                desc,
                creatorUser,
                referUser,
                status,
                priority,
                remindDate,
                alarmDate,
                remindTime,
                isRemind,
                isBookMark,
                doingTime
            );

            workflowContext.Input[$"{Output}.Id"] = conversationId;

            return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}