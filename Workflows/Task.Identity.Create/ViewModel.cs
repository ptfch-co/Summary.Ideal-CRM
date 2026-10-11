namespace Summary.IdealCrm.Workflows.Task.CreateIdentity
{
    using System.ComponentModel.DataAnnotations;

    public class CreateIdentityInIdealCrmTaskViewModel
    {
        public string IdentityType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Group_1 { get; set; }
        public string Presentation { get; set; }
        public string NationalId { get; set; }
        public string EconomicCode { get; set; }
        public string RegisterNumber { get; set; }
        public string PostalCode { get; set; }
        public string PostalBox { get; set; }
        public string CmpEmail { get; set; }
        public string CmpPhone { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public string PrsEmail { get; set; }
        public string NationalCode { get; set; }
        public string PrsAddress { get; set; }
        public string PrsDescription { get; set; }
        public string PrsPhone { get; set; }
        [Required]
        public string AssignTo { get; set; }
        public string CreatorUser { get; set; }
        public string Campaign { get; set; }
    }
}