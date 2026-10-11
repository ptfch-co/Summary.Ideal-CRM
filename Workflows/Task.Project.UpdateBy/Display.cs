namespace Summary.IdealCrm.Workflows.Task.Project.UpdateBy
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;
    
    public class UpdateProjectByInIdealCrmTaskDisplay : ActivityDisplayDriver<UpdateProjectByInIdealCrmTask,
        UpdateProjectByInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(UpdateProjectByInIdealCrmTask activity, 
            UpdateProjectByInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Filter = activity.Filter;
            model.Title = activity.Title.Expression;
            model.TitleEditable = activity.TitleEditable;
            model.Desc = activity.Desc.Expression;
            model.DescEditable = activity.DescEditable;
            model.StartDate = activity.StartDate.Expression;
            model.StartDateEditable = activity.StartDateEditable;
            model.StarterUser = activity.StarterUser.Expression;
            model.StarterUserEditable = activity.StarterUserEditable;
            model.Grade = activity.Grade.Expression;
            model.GradeEditable = activity.GradeEditable;
            model.Priority = activity.Priority.Expression;
            model.PriorityEditable = activity.PriorityEditable;
            model.Group = activity.Group.Expression;
            model.GroupEditable = activity.GroupEditable;
            model.CnvsStatusGroup = activity.CnvsStatusGroup.Expression;
            model.CnvsStatusGroupEditable = activity.ConvStatusGroupEditable;
            model.PostFix = activity.PostFix.Expression;
            model.PostFixEditable = activity.PostFixEditable;
            model.RemindDateTime = activity.RemindDateTime.Expression;
            model.RemindDateTimeEditable = activity.RemindDateTimeEditable;
            model.CmpPresentation = activity.CmpPresentation.Expression;
            model.CmpPresentationEditable = activity.CmpPresentationEditable;
            model.IsFinished = activity.IsFinished.Expression;
            model.IsFinishedEditable = activity.IsFinishedEditable;
        }

        protected override void UpdateActivity(UpdateProjectByInIdealCrmTaskViewModel model, 
            UpdateProjectByInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.Filter = model.Filter;
            activity.Title = new WorkflowExpression<string>(model.Title);
            activity.TitleEditable = model.TitleEditable;
            activity.Desc = new WorkflowExpression<string>(model.Desc);
            activity.DescEditable = model.DescEditable;
            activity.StartDate = new WorkflowExpression<string>(model.StartDate);
            activity.StartDateEditable = model.StartDateEditable;
            activity.StarterUser = new WorkflowExpression<string>(model.StarterUser);
            activity.StarterUserEditable = model.StarterUserEditable;
            activity.Grade = new WorkflowExpression<string>(model.Grade);
            activity.GradeEditable = model.GradeEditable;
            activity.Priority = new WorkflowExpression<string>(model.Priority);
            activity.PriorityEditable = model.PriorityEditable;
            activity.Group = new WorkflowExpression<string>(model.Group);
            activity.GroupEditable = model.GroupEditable;
            activity.CnvsStatusGroup = new WorkflowExpression<string>(model.CnvsStatusGroup);
            activity.ConvStatusGroupEditable = model.CnvsStatusGroupEditable;
            activity.PostFix = new WorkflowExpression<string>(model.PostFix);
            activity.PostFixEditable = model.PostFixEditable;
            activity.RemindDateTime = new WorkflowExpression<string>(model.RemindDateTime);
            activity.RemindDateTimeEditable = model.RemindDateTimeEditable;
            activity.CmpPresentation = new WorkflowExpression<string>(model.CmpPresentation);
            activity.CmpPresentationEditable = model.CmpPresentationEditable;
            activity.IsFinished = new WorkflowExpression<string>(model.IsFinished);
            activity.IsFinishedEditable = model.IsFinishedEditable;
        }
    }
}