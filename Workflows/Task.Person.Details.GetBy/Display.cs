namespace Summary.IdealCrm.Workflows.Task.Person.Details.GetBy
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;
    
    public class GetPersonDetailsByInIdealCrmTaskDisplay : ActivityDisplayDriver<GetPersonDetailsByInIdealCrmTask,
        GetPersonDetailsByInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(GetPersonDetailsByInIdealCrmTask activity, 
            GetPersonDetailsByInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Filter = activity.Filter;
            model.SearchKind = activity.SearchKind;
            model.Output = activity.Output;
        }

        protected override void UpdateActivity(GetPersonDetailsByInIdealCrmTaskViewModel model, 
            GetPersonDetailsByInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.Filter = model.Filter;
            activity.SearchKind = model.SearchKind;
            activity.Output = model.Output;
        }
    }
}