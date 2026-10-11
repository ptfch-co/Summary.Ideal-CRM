namespace Summary.IdealCrm.Workflows.Task.Identity.UpdateBy
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateIdentityByInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        public IdentitySearchKind SearchKind { get; set; }
        [Required]
        public string Filter { get; set; }
        public bool IsIdentityTypeEditable { get; set; }
        public string IdentityType { get; set; }
        public bool IsSubjectEditable { get; set; }
        public string Subject { get; set; }
        public bool IsTypeEditable { get; set; }
        public string Type { get; set; }
        public bool IsCountryEditable { get; set; }
        public string Country { get; set; }
        public bool IsProvinceEditable { get; set; }
        public string Province { get; set; }
        public bool IsCityEditable { get; set; }
        public string City { get; set; }
        public bool IsDescriptionEditable { get; set; }
        public string Description { get; set; }
        public bool IsAddressEditable { get; set; }
        public string Address { get; set; }
        public bool IsGroupEditable { get; set; }
        public string Group { get; set; }
        public bool IsPresentationEditable { get; set; }
        public string Presentation { get; set; }
        public bool IsNationalIdEditable { get; set; }
        public string NationalId { get; set; }
        public bool IsEconomicCodeEditable { get; set; }
        public string EconomicCode { get; set; }
        public bool IsRegisterNumberEditable { get; set; }
        public string RegisterNumber { get; set; }
        public bool IsPostalCodeEditable { get; set; }
        public string PostalCode { get; set; }
        public bool IsPostalBoxEditable { get; set; }
        public string PostalBox { get; set; }
        public bool IsCmpEmailEditable { get; set; }
        public string CmpEmail { get; set; }
        public bool IsCmpPhoneEditable { get; set; }
        public string CmpPhone { get; set; }
        public bool IsAssignToEditable { get; set; }
        public string AssignTo { get; set; }
        public bool IsCampaignEditable { get; set; }
        public bool AddToCampaign { get; set; }
        public string Campaign { get; set; }
        public bool IsMobileEditable { get; set; }
        public string Mobile { get; set; }
        public bool IsFirstNameEditable { get; set; }
        public string FirstName { get; set; }
        public bool IsLastNameEditable { get; set; }
        public string LastName { get; set; }
        public bool IsJobEditable { get; set; }
        public string Job { get; set; }
        public bool IsDepartmentEditable { get; set; }
        public string Department { get; set; }
        public bool IsPrsEmailEditable { get; set; }
        public string PrsEmail { get; set; }
        public bool IsNationalCodeEditable { get; set; }
        public string NationalCode { get; set; }
        public bool IsPrsAddressEditable { get; set; }
        public string PrsAddress { get; set; }
        public bool IsPrsDescriptionEditable { get; set; }
        public string PrsDescription { get; set; }
        public bool IsPrsPhoneEditable { get; set; }
        public string PrsPhone { get; set; }
    }
}