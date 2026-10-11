namespace Summary.IdealCrm.Workflows.Task.Quote.Create
{
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Core.Mvc.Utilities;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreateQuoteInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<CreateQuoteInIdealCrmTask> T;
        private readonly ILogger<CreateQuoteInIdealCrmTask> _logger;
        private readonly IQuoteService _quote;

        public CreateQuoteInIdealCrmTask(IStringLocalizer<CreateQuoteInIdealCrmTask> t,
            ILogger<CreateQuoteInIdealCrmTask> logger,
            IQuoteService quote)
        {
            T = t;
            _logger = logger;
            _quote = quote;
        }

        public override string Name => nameof(CreateQuoteInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfCreateQuote];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done]);
        }

        public string Company
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public string Personnel
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public string Project
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public string Title
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Number
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Date
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Subject
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public string QuoteItemCount
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public string QuoteItemFormat
        {
            get => GetProperty(() => String.Empty);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> DiscountTitle
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IsVerified
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Status
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Group
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Fixed
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PayCondition
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Description
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Description2
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrintFormat
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> AccountNumber
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> ShabaNumber
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Address
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Telephone
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Website
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Email
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> TransportationCost
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> ReferUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CreatorUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> OutputQuote
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public string TotalDiscount
        {
            get => GetProperty(() => string.Empty);
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            var userName = workflowContext.GetInputOrDefault(UserName.Expression);
            var password = workflowContext.GetInputOrDefault(Password.Expression);
            var company = workflowContext.GetInputOrDefault(Company);
            var personnel = workflowContext.GetInputOrDefault(Personnel);
            var project = workflowContext.GetInputOrDefault(Project);
            var title = workflowContext.GetInputOrDefault(Title);
            var number = workflowContext.GetInputOrDefault(Number.Expression);
            var date = workflowContext.GetInputOrDefault(Date.Expression).ConvertTo<DateTime>();
            var subject = workflowContext.GetInputOrDefault(Subject.Expression);
            var quoteItemCount = workflowContext.GetInputOrDefault(QuoteItemCount).ConvertTo<int>().Value;
            var discountTitle = workflowContext.GetInputOrDefault(DiscountTitle.Expression);
            var isVerified = workflowContext.GetInputOrDefault(IsVerified.Expression).ToBoolean();
            var status = workflowContext.GetInputOrDefault(Status.Expression);
            var group = workflowContext.GetInputOrDefault(Group.Expression);
            var isFixed = workflowContext.GetInputOrDefault(Fixed.Expression).ToBoolean();
            var payCondition = workflowContext.GetInputOrDefault(PayCondition.Expression);
            var description = workflowContext.GetInputOrDefault(Description.Expression);
            var description2 = workflowContext.GetInputOrDefault(Description2.Expression);
            var printFormat = workflowContext.GetInputOrDefault(PrintFormat.Expression);
            var accountNumber = workflowContext.GetInputOrDefault(AccountNumber.Expression);
            var shabaNumber = workflowContext.GetInputOrDefault(ShabaNumber.Expression);
            var address = workflowContext.GetInputOrDefault(Address.Expression);
            var telephone = workflowContext.GetInputOrDefault(Telephone.Expression);
            var website = workflowContext.GetInputOrDefault(Website.Expression);
            var email = workflowContext.GetInputOrDefault(Email.Expression);
            var transportationCost = workflowContext.GetInputOrDefault(TransportationCost.Expression);
            var referUser = workflowContext.GetInputOrDefault(ReferUser.Expression);
            var creatorUser = workflowContext.GetInputOrDefault(CreatorUser.Expression);
            var outputQuote = workflowContext.GetInputOrDefault(OutputQuote.Expression);
            var total_discount = workflowContext.GetInputOrDefault(TotalDiscount).ConvertTo<long>() ?? 0;

            QuoteCreateInfo quote_response = await _quote.CreateAsync(
                userName,
                password,
                company,
                personnel,
                project,
                title,
                number,
                date,
                subject,
                discountTitle,
                isVerified,
                status,
                group,
                isFixed,
                payCondition,
                description,
                description2,
                printFormat,
                accountNumber,
                shabaNumber,
                address,
                telephone,
                website,
                email,
                transportationCost,
                referUser,
                creatorUser,
                total_discount
            );

            if (String.IsNullOrWhiteSpace(outputQuote)) outputQuote = "Output.Ideal.Quote";

            workflowContext.Input[$"{outputQuote}.Id"] = quote_response.PreOrderId;
            workflowContext.Input[$"{outputQuote}.Number"] = quote_response.PreOrderNumber;

            for (var i = 1; i <= quoteItemCount; i++)
            {
                // Params Keys
                var count = $"{String.Format(QuoteItemFormat, i)}.Count";
                var code = $"{String.Format(QuoteItemFormat, i)}.Code";
                var inventoryCode = $"{String.Format(QuoteItemFormat, i)}.InventoryCode";
                var discount = workflowContext.GetInputOrDefault($"{String.Format(QuoteItemFormat, i)}.Discount").ConvertTo<long>() ?? 0;
                var base_unit_price = workflowContext.GetInputOrDefault($"{String.Format(QuoteItemFormat, i)}.BaseUnitPrice").ConvertTo<long>() ?? 0;
                var totalVat = $"{String.Format(QuoteItemFormat, i)}.TotalVat";
                var totalToll = $"{String.Format(QuoteItemFormat, i)}.TotalToll";
                var item_description = $"{String.Format(QuoteItemFormat, i)}.Description";
                var total_price = workflowContext.GetInputOrDefault($"{String.Format(QuoteItemFormat, i)}.FinalUnitPrice").ConvertTo<long>() ?? 0;

                var countValue = workflowContext.GetInputOrDefault(count).ConvertTo<int>().Value;
                var totalVatValue = workflowContext.GetInputOrDefault(totalVat).ConvertTo<float>() ?? 0;
                var totalTollValue = workflowContext.GetInputOrDefault(totalToll).ConvertTo<float>() ?? 0;

                await _quote.InsertItemAsync(
                    // نام کاربری
                    userName,
                    // گذرواژه
                    password,
                    // شناسه پیش فاکتور
                    quote_response.PreOrderId,
                    // کد محصول
                    workflowContext.GetInputOrDefault(code),
                    // تعداد
                    countValue,
                    base_unit_price,
                    total_price,
                    // کد انبار
                    workflowContext.GetInputOrDefault(inventoryCode),
                    discount,
                    // مجموع مالیات و عوارض
                    totalTollValue + totalVatValue,
                    // ایجاد توسط
                    creatorUser,
                    // توضیحات قلم کالا
                    workflowContext.GetInputOrDefault(item_description)
                );
            }

            return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}