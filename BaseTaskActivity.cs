namespace Summary.IdealCrm
{
    using Core.Workflows.Activities;
    using Core.Workflows.Models;

    public abstract class BaseTaskActivity : TaskActivity
    {
        public WorkflowExpression<string> UserName
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Password
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }
    }
}