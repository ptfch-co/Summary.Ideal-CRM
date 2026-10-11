namespace Summary.IdealCrm.Workflows.Task.Conversation.Create
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;
    
    public class CreateConversationInIdealCrmTaskDisplay : ActivityDisplayDriver<CreateConversationInIdealCrmTask,
        CreateConversationInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(CreateConversationInIdealCrmTask activity, 
            CreateConversationInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Company = activity.CompanyId.Expression;
            model.Person = activity.PersonId.Expression;
            model.Project = activity.ProjectId.Expression;
            model.Date = activity.Date.Expression;
            model.Type = activity.Type.Expression;
            model.Desc = activity.Desc.Expression;
            model.CreatorUser = activity.CreatorUser.Expression;
            model.ReferUser = activity.ReferUser.Expression;
            model.Status = activity.Status.Expression;
            model.Priority = activity.Priority.Expression;
            model.RemindDate = activity.RemindDate.Expression;
            model.AlarmDate = activity.AlarmDate.Expression;
            model.RemindTime = activity.RemindTime.Expression;
            model.IsRemind = activity.IsRemind.Expression;
            model.IsBookMark = activity.IsBookMark.Expression;
            model.DoingTime = activity.DoingTime.Expression;
            model.Output = activity.Output;
        }

        protected override void UpdateActivity(CreateConversationInIdealCrmTaskViewModel model, 
            CreateConversationInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.CompanyId = new WorkflowExpression<string>(model.Company);
            activity.PersonId = new WorkflowExpression<string>(model.Person);
            activity.ProjectId = new WorkflowExpression<string>(model.Project);
            activity.Date = new WorkflowExpression<string>(model.Date);
            activity.Type = new WorkflowExpression<string>(model.Type);
            activity.Desc = new WorkflowExpression<string>(model.Desc);
            activity.CreatorUser = new WorkflowExpression<string>(model.CreatorUser);
            activity.ReferUser = new WorkflowExpression<string>(model.ReferUser);
            activity.Status = new WorkflowExpression<string>(model.Status);
            activity.Priority = new WorkflowExpression<string>(model.Priority);
            activity.RemindDate = new WorkflowExpression<string>(model.RemindDate);
            activity.AlarmDate = new WorkflowExpression<string>(model.AlarmDate);
            activity.RemindTime = new WorkflowExpression<string>(model.RemindTime);
            activity.IsRemind = new WorkflowExpression<string>(model.IsRemind);
            activity.IsBookMark = new WorkflowExpression<string>(model.IsBookMark);
            activity.DoingTime = new WorkflowExpression<string>(model.DoingTime);
            activity.Output = model.Output;
        }
    }
}