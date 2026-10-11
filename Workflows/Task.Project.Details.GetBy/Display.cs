namespace Summary.IdealCrm.Workflows.Task.Project.Details.GetBy
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;

    public class GetProjectDetailsByInIdealCrmTaskDisplay : ActivityDisplayDriver<GetProjectDetailsByInIdealCrmTask,
        GetProjectDetailsByInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(GetProjectDetailsByInIdealCrmTask activity, 
            GetProjectDetailsByInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Filter = activity.Filter;
            model.SearchKind = activity.SearchKind;
            model.Output = activity.Output;
        }

        protected override void UpdateActivity(GetProjectDetailsByInIdealCrmTaskViewModel model, 
            GetProjectDetailsByInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.Filter = model.Filter;
            activity.SearchKind = model.SearchKind;
            activity.Output = model.Output;
        }
    }
}