namespace Summary.IdealCrm.Workflows.Task.Project.Create
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;
    
    public class CreateProjectInIdealCrmTaskDisplay : ActivityDisplayDriver<CreateProjectInIdealCrmTask,
        CreateProjectInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(CreateProjectInIdealCrmTask activity, 
            CreateProjectInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Company = activity.CompanyId;
            model.Title = activity.Title;
            model.InquiryNumber = activity.InquiryNumber.Expression;
            model.Desc = activity.Desc.Expression;
            model.StartDate = activity.StartDate.Expression;
            model.StarterUser = activity.StarterUser.Expression;
            model.Grade = activity.Grade.Expression;
            model.Priority = activity.Priority.Expression;
            model.Group = activity.Group.Expression;
            model.CnvsStatusGroup = activity.CnvsStatusGroup.Expression;
            model.PostFix = activity.PostFix.Expression;
            model.RemindDateTime = activity.RemindDateTime.Expression;
            model.IsTicket = activity.IsTicket.Expression;
            model.CmpPresentation = activity.CmpPresentation.Expression;
            model.IsFinished = activity.IsFinished.Expression;
            model.Campaign = activity.Campaign.Expression;
            model.CreatorUser = activity.CreatorUser.Expression;
            model.Output = activity.Output;
        }

        protected override void UpdateActivity(CreateProjectInIdealCrmTaskViewModel model, 
            CreateProjectInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.CompanyId = model.Company;
            activity.Title = model.Title;
            activity.InquiryNumber = new WorkflowExpression<string>(model.InquiryNumber);
            activity.Desc = new WorkflowExpression<string>(model.Desc);
            activity.StartDate = new WorkflowExpression<string>(model.StartDate);
            activity.StarterUser = new WorkflowExpression<string>(model.StarterUser);
            activity.Grade = new WorkflowExpression<string>(model.Grade);
            activity.Priority = new WorkflowExpression<string>(model.Priority);
            activity.Group = new WorkflowExpression<string>(model.Group);
            activity.CnvsStatusGroup = new WorkflowExpression<string>(model.CnvsStatusGroup);
            activity.PostFix = new WorkflowExpression<string>(model.PostFix);
            activity.RemindDateTime = new WorkflowExpression<string>(model.RemindDateTime);
            activity.IsTicket = new WorkflowExpression<string>(model.IsTicket);
            activity.CmpPresentation = new WorkflowExpression<string>(model.CmpPresentation);
            activity.IsFinished = new WorkflowExpression<string>(model.IsFinished);
            activity.Campaign = new WorkflowExpression<string>(model.Campaign);
            activity.CreatorUser = new WorkflowExpression<string>(model.CreatorUser);
            activity.Output = model.Output;
        }
    }
}