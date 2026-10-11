namespace Summary.IdealCrm.Workflows.Task.Quote.Create
{
    using System.ComponentModel.DataAnnotations;
    using Summary.IdealCrm;

    public class CreateQuoteInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Personnel { get; set; }
        [Required]
        public string Project { get; set; }
        [Required]
        public string Title { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string Subject { get; set; }
        [Required]
        public string QuoteItemCount { get; set; }
        [Required]
        public string QuoteItemFormat { get; set; }
        public string DiscountTitle { get; set; }
        public string IsVerified { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public string Fixed { get; set; }
        public string PayCondition { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string PrintFormat { get; set; }
        public string AccountNumber { get; set; }
        public string ShabaNumber { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string TransportationCost { get; set; }
        public string ReferUser { get; set; }
        public string CreatorUser { get; set; }
        public string TotalDiscount { get; set; }
        public string OutputQuote { get; set; }
    }
}