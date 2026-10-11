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
            model.ExpireDateTime = activity.ExpireDateTime.Expression;
            model.Subject = activity.Subject.Expression;
            model.QuoteItemCount = activity.QuoteItemCount;
            model.QuoteItemFormat = activity.QuoteItemFormat;
            model.DiscountPercent = activity.DiscountPercent.Expression;
            model.DiscountTitle = activity.DiscountTitle.Expression;
            model.TaxPercent = activity.TaxPercent.Expression;
            model.Round = activity.Round.Expression;
            model.IsVerified = activity.IsVerified.Expression;
            model.UserVerified = activity.UserVerified.Expression;
            model.Status = activity.Status.Expression;
            model.Group = activity.Group.Expression;
            model.Fixed = activity.Fixed.Expression;
            model.Warranty = activity.Warranty.Expression;
            model.PayCondition = activity.PayCondition.Expression;
            model.DeliveryTimeKind = activity.DeliveryTimeKind.Expression;
            model.DeliveryDateTime = activity.DeliveryDateTime.Expression;
            model.DeliveryEndDateTime = activity.DeliveryEndDateTime.Expression;
            model.CreditDuration = activity.CreditDuration.Expression;
            model.SpecialWord = activity.SpecialWord.Expression;
            model.Description = activity.Description.Expression;
            model.Description2 = activity.Description2.Expression;
            model.PrintFormat = activity.PrintFormat.Expression;
            model.AccountNumber = activity.AccountNumber.Expression;
            model.ShabaNumber = activity.ShabaNumber.Expression;
            model.AccountNumber2 = activity.AccountNumber2.Expression;
            model.ShabaNumber2 = activity.ShabaNumber2.Expression;
            model.Address = activity.Address.Expression;
            model.Telephone = activity.Telephone.Expression;
            model.Fax = activity.Fax.Expression;
            model.Website = activity.Website.Expression;
            model.Email = activity.Email.Expression;
            model.TransportationCost = activity.TransportationCost.Expression;
            model.ReferUser = activity.ReferUser.Expression;
            model.CreatorUser = activity.CreatorUser.Expression;
            model.OutputQuote = activity.OutputQuote.Expression;
            model.CreatePayment = activity.CreatePayment;
            model.PayType = activity.PayType.Expression;
            model.PayAmount = activity.PayAmount.Expression;
            model.PayNumber = activity.PayNumber.Expression;
            model.PayDescription = activity.PayDescription.Expression;
            model.PayDate = activity.PayDate.Expression;
            model.DocumentAmount = activity.DocumentAmount.Expression;
            model.OutputPayment = activity.OutputPayment.Expression;
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
            activity.ExpireDateTime = new WorkflowExpression<string>(model.ExpireDateTime);
            activity.Subject = new WorkflowExpression<string>(model.Subject);
            activity.QuoteItemCount = model.QuoteItemCount;
            activity.QuoteItemFormat = model.QuoteItemFormat;
            activity.DiscountPercent = new WorkflowExpression<string>(model.DiscountPercent);
            activity.DiscountTitle = new WorkflowExpression<string>(model.DiscountTitle);
            activity.TaxPercent = new WorkflowExpression<string>(model.TaxPercent);
            activity.Round = new WorkflowExpression<string>(model.Round);
            activity.IsVerified = new WorkflowExpression<string>(model.IsVerified);
            activity.UserVerified = new WorkflowExpression<string>(model.UserVerified);
            activity.Status = new WorkflowExpression<string>(model.Status);
            activity.Group = new WorkflowExpression<string>(model.Group);
            activity.Fixed = new WorkflowExpression<string>(model.Fixed);
            activity.Warranty = new WorkflowExpression<string>(model.Warranty);
            activity.PayCondition = new WorkflowExpression<string>(model.PayCondition);
            activity.DeliveryTimeKind = new WorkflowExpression<string>(model.DeliveryTimeKind);
            activity.DeliveryDateTime = new WorkflowExpression<string>(model.DeliveryDateTime);
            activity.DeliveryEndDateTime = new WorkflowExpression<string>(model.DeliveryEndDateTime);
            activity.CreditDuration = new WorkflowExpression<string>(model.CreditDuration);
            activity.SpecialWord = new WorkflowExpression<string>(model.SpecialWord);
            activity.Description = new WorkflowExpression<string>(model.Description);
            activity.Description2 = new WorkflowExpression<string>(model.Description2);
            activity.PrintFormat = new WorkflowExpression<string>(model.PrintFormat);
            activity.AccountNumber = new WorkflowExpression<string>(model.AccountNumber);
            activity.ShabaNumber = new WorkflowExpression<string>(model.ShabaNumber);
            activity.AccountNumber2 = new WorkflowExpression<string>(model.AccountNumber2);
            activity.ShabaNumber2 = new WorkflowExpression<string>(model.ShabaNumber2);
            activity.Address = new WorkflowExpression<string>(model.Address);
            activity.Telephone = new WorkflowExpression<string>(model.Telephone);
            activity.Fax = new WorkflowExpression<string>(model.Fax);
            activity.Website = new WorkflowExpression<string>(model.Website);
            activity.Email = new WorkflowExpression<string>(model.Email);
            activity.TransportationCost = new WorkflowExpression<string>(model.TransportationCost);
            activity.ReferUser = new WorkflowExpression<string>(model.ReferUser);
            activity.CreatorUser = new WorkflowExpression<string>(model.CreatorUser);
            activity.OutputQuote = new WorkflowExpression<string>(model.OutputQuote);
            activity.CreatePayment = model.CreatePayment;
            activity.PayType = new WorkflowExpression<string>(model.PayType);
            activity.PayAmount = new WorkflowExpression<string>(model.PayAmount);
            activity.PayNumber = new WorkflowExpression<string>(model.PayNumber);
            activity.PayDescription = new WorkflowExpression<string>(model.PayDescription);
            activity.PayDate = new WorkflowExpression<string>(model.PayDate);
            activity.DocumentAmount = new WorkflowExpression<string>(model.DocumentAmount);
            activity.OutputPayment = new WorkflowExpression<string>(model.OutputPayment);
        }
    }
}