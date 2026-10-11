namespace Summary.IdealCrm.Workflows.Task.Quote.Create
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;

    public class CreateQuoteInIdealCrmTaskDisplay : ActivityDisplayDriver<CreateQuoteInIdealCrmTask,
        CreateQuoteInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(CreateQuoteInIdealCrmTask activity,
            CreateQuoteInIdealCrmTaskViewModel model)
        {
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Company = activity.Company;
            model.Personnel = activity.Personnel;
            model.Project = activity.Project;
            model.Title = activity.Title;
            model.Number = activity.Number.Expression;
            model.Date = activity.Date.Expression;
            model.Subject = activity.Subject.Expression;
            model.QuoteItemCount = activity.QuoteItemCount;
            model.QuoteItemFormat = activity.QuoteItemFormat;
            model.DiscountTitle = activity.DiscountTitle.Expression;
            model.IsVerified = activity.IsVerified.Expression;
            model.Status = activity.Status.Expression;
            model.Group = activity.Group.Expression;
            model.Fixed = activity.Fixed.Expression;
            model.PayCondition = activity.PayCondition.Expression;
            model.Description = activity.Description.Expression;
            model.Description2 = activity.Description2.Expression;
            model.PrintFormat = activity.PrintFormat.Expression;
            model.AccountNumber = activity.AccountNumber.Expression;
            model.ShabaNumber = activity.ShabaNumber.Expression;
            model.Address = activity.Address.Expression;
            model.Telephone = activity.Telephone.Expression;
            model.Website = activity.Website.Expression;
            model.Email = activity.Email.Expression;
            model.TransportationCost = activity.TransportationCost.Expression;
            model.ReferUser = activity.ReferUser.Expression;
            model.CreatorUser = activity.CreatorUser.Expression;
            model.OutputQuote = activity.OutputQuote.Expression;
            model.TotalDiscount = activity.TotalDiscount;
        }

        protected override void UpdateActivity(CreateQuoteInIdealCrmTaskViewModel model,
            CreateQuoteInIdealCrmTask activity)
        {
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.Company = model.Company;
            activity.Personnel = model.Personnel;
            activity.Project = model.Project;
            activity.Title = model.Title;
            activity.Number = new WorkflowExpression<string>(model.Number);
            activity.Date = new WorkflowExpression<string>(model.Date);
            activity.Subject = new WorkflowExpression<string>(model.Subject);
            activity.QuoteItemCount = model.QuoteItemCount;
            activity.QuoteItemFormat = model.QuoteItemFormat;
            activity.DiscountTitle = new WorkflowExpression<string>(model.DiscountTitle);
            activity.IsVerified = new WorkflowExpression<string>(model.IsVerified);
            activity.Status = new WorkflowExpression<string>(model.Status);
            activity.Group = new WorkflowExpression<string>(model.Group);
            activity.Fixed = new WorkflowExpression<string>(model.Fixed);
            activity.PayCondition = new WorkflowExpression<string>(model.PayCondition);
            activity.Description = new WorkflowExpression<string>(model.Description);
            activity.Description2 = new WorkflowExpression<string>(model.Description2);
            activity.PrintFormat = new WorkflowExpression<string>(model.PrintFormat);
            activity.AccountNumber = new WorkflowExpression<string>(model.AccountNumber);
            activity.ShabaNumber = new WorkflowExpression<string>(model.ShabaNumber);
            activity.Address = new WorkflowExpression<string>(model.Address);
            activity.Telephone = new WorkflowExpression<string>(model.Telephone);
            activity.Website = new WorkflowExpression<string>(model.Website);
            activity.Email = new WorkflowExpression<string>(model.Email);
            activity.TransportationCost = new WorkflowExpression<string>(model.TransportationCost);
            activity.ReferUser = new WorkflowExpression<string>(model.ReferUser);
            activity.CreatorUser = new WorkflowExpression<string>(model.CreatorUser);
            activity.OutputQuote = new WorkflowExpression<string>(model.OutputQuote);
            activity.TotalDiscount = model.TotalDiscount;
        }
    }
}