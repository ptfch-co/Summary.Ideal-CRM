namespace Summary.IdealCrm.Workflows.Task.CreateIdentity
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;

    public class CreateIdentityInIdealCrmTaskDisplay : ActivityDisplayDriver<CreateIdentityInIdealCrmTask,
        CreateIdentityInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(CreateIdentityInIdealCrmTask activity, 
            CreateIdentityInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Subject = activity.Subject.Expression;
            model.Type = activity.Type.Expression;
            model.Country = activity.Country.Expression;
            model.Province = activity.Province.Expression;
            model.City = activity.City.Expression;
            model.Mobile = activity.Mobile.Expression;
            model.FirstName = activity.FirstName.Expression;
            model.LastName = activity.LastName.Expression;
            model.Prefix = activity.Prefix.Expression;
            model.IdentityType = activity.IdentityType.Expression;
            model.Description = activity.Description.Expression;
            model.Address = activity.Address.Expression;
            model.Group_1 = activity.Group_1.Expression;
            model.Presentation = activity.Presentation.Expression;
            model.NationalId = activity.NationalId.Expression;
            model.EconomicCode = activity.EconomicCode.Expression;
            model.RegisterNumber = activity.RegisterNumber.Expression;
            model.PostalCode = activity.PostalCode.Expression;
            model.PostalBox = activity.PostalBox.Expression;
            model.CmpEmail = activity.CmpEmail.Expression;
            model.CmpPhone = activity.CmpPhone.Expression;
            model.Job = activity.Job.Expression;
            model.Department = activity.Department.Expression;
            model.PrsEmail = activity.PrsEmail.Expression;
            model.NationalCode = activity.NationalCode.Expression;
            model.PrsAddress = activity.PrsAddress.Expression;
            model.PrsDescription = activity.PrsDescription.Expression;
            model.PrsPhone = activity.PrsPhone.Expression;  
            model.AssignTo = activity.AssignTo.Expression;
            model.CreatorUser = activity.CreatorUser.Expression;
            model.Campaign = activity.Campaign.Expression;
        }

        protected override void UpdateActivity(CreateIdentityInIdealCrmTaskViewModel model, 
            CreateIdentityInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.Subject = new WorkflowExpression<string>(model.Subject);
            activity.Type = new WorkflowExpression<string>(model.Type);
            activity.Country = new WorkflowExpression<string>(model.Country);
            activity.Province = new WorkflowExpression<string>(model.Province);
            activity.City = new WorkflowExpression<string>(model.City);
            activity.Mobile = new WorkflowExpression<string>(model.Mobile);
            activity.FirstName = new WorkflowExpression<string>(model.FirstName);
            activity.LastName = new WorkflowExpression<string>(model.LastName);
            activity.Prefix = new WorkflowExpression<string>(model.Prefix);
            activity.IdentityType = new WorkflowExpression<string>(model.IdentityType);
            activity.Description = new WorkflowExpression<string>(model.Description);
            activity.Address = new WorkflowExpression<string>(model.Address);
            activity.Group_1 = new WorkflowExpression<string>(model.Group_1);
            activity.Presentation = new WorkflowExpression<string>(model.Presentation);
            activity.NationalId = new WorkflowExpression<string>(model.NationalId);
            activity.EconomicCode = new WorkflowExpression<string>(model.EconomicCode);
            activity.RegisterNumber = new WorkflowExpression<string>(model.RegisterNumber);
            activity.PostalCode = new WorkflowExpression<string>(model.PostalCode);
            activity.PostalBox = new WorkflowExpression<string>(model.PostalBox);
            activity.CmpEmail = new WorkflowExpression<string>(model.CmpEmail);
            activity.CmpPhone = new WorkflowExpression<string>(model.CmpPhone);
            activity.Job = new WorkflowExpression<string>(model.Job);
            activity.Department = new WorkflowExpression<string>(model.Department);
            activity.PrsEmail = new WorkflowExpression<string>(model.PrsEmail);
            activity.NationalCode = new WorkflowExpression<string>(model.NationalCode);
            activity.PrsAddress = new WorkflowExpression<string>(model.PrsAddress);
            activity.PrsDescription = new WorkflowExpression<string>(model.PrsDescription);
            activity.PrsPhone = new WorkflowExpression<string>(model.PrsPhone); 
            activity.AssignTo = new WorkflowExpression<string>(model.AssignTo);
            activity.CreatorUser = new WorkflowExpression<string>(model.CreatorUser);
            activity.Campaign = new WorkflowExpression<string>(model.Campaign);
        }
    }
}