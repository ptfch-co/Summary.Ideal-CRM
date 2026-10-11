namespace Summary.IdealCrm.Workflows.Task.Identity.UpdateBy
{
    using Core.Workflows.Display;
    using Core.Workflows.Models;

    public class UpdateIdentityByInIdealCrmTaskDisplay : ActivityDisplayDriver<UpdateIdentityByInIdealCrmTask,
        UpdateIdentityByInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(UpdateIdentityByInIdealCrmTask activity,
            UpdateIdentityByInIdealCrmTaskViewModel model)
        {
            model.SearchKind = activity.SearchKind;
            model.UserName = activity.UserName.Expression;
            model.Password = activity.Password.Expression;
            model.Filter = activity.Filter;
            model.IsIdentityTypeEditable = activity.IsIdentityTypeEditable;
            model.IdentityType = activity.IdentityType.Expression;
            model.IsSubjectEditable = activity.IsSubjectEditable;
            model.Subject = activity.Subject.Expression;
            model.IsTypeEditable = activity.IsTypeEditable;
            model.Type = activity.Type.Expression;
            model.IsCountryEditable = activity.IsCountryEditable;
            model.Country = activity.Country.Expression;
            model.IsProvinceEditable = activity.IsProvinceEditable;
            model.Province = activity.Province.Expression;
            model.IsCityEditable = activity.IsCityEditable;
            model.City = activity.City.Expression;
            model.IsMobileEditable = activity.IsMobileEditable;
            model.Mobile = activity.Mobile.Expression;
            model.IsFirstNameEditable = activity.IsFirstNameEditable;
            model.FirstName = activity.FirstName.Expression;
            model.IsLastNameEditable = activity.IsLastNameEditable;
            model.LastName = activity.LastName.Expression;
            model.IsDescriptionEditable = activity.IsDescriptionEditable;
            model.Description = activity.Description.Expression;
            model.IsAddressEditable = activity.IsAddressEditable;
            model.Address = activity.Address.Expression;
            model.IsGroupEditable = activity.IsGroupEditable;
            model.Group = activity.Group.Expression;
            model.IsPresentationEditable = activity.IsPresentationEditable;
            model.Presentation = activity.Presentation.Expression;
            model.IsNationalIdEditable = activity.IsNationalIdEditable;
            model.NationalId = activity.NationalId.Expression;
            model.IsEconomicCodeEditable = activity.IsEconomicCodeEditable;
            model.EconomicCode = activity.EconomicCode.Expression;
            model.IsRegisterNumberEditable = activity.IsRegisterNumberEditable;
            model.RegisterNumber = activity.RegisterNumber.Expression;
            model.IsPostalCodeEditable = activity.IsPostalCodeEditable;
            model.PostalCode = activity.PostalCode.Expression;
            model.IsPostalBoxEditable = activity.IsPostalBoxEditable;
            model.PostalBox = activity.PostalBox.Expression;
            model.IsCmpEmailEditable = activity.IsCmpEmailEditable;
            model.CmpEmail = activity.CmpEmail.Expression;
            model.IsCmpPhoneEditable = activity.IsCmpPhoneEditable;
            model.CmpPhone = activity.CmpPhone.Expression;
            model.IsJobEditable = activity.IsJobEditable;
            model.Job = activity.Job.Expression;
            model.IsDepartmentEditable = activity.IsDepartmentEditable;
            model.Department = activity.Department.Expression;
            model.IsPrsEmailEditable = activity.IsPrsEmailEditable;
            model.PrsEmail = activity.PrsEmail.Expression;
            model.IsNationalCodeEditable = activity.IsNationalCodeEditable;
            model.NationalCode = activity.NationalCode.Expression;
            model.IsPrsAddressEditable = activity.IsPrsAddressEditable;
            model.PrsAddress = activity.PrsAddress.Expression;
            model.IsPrsDescriptionEditable = activity.IsPrsDescriptionEditable;
            model.PrsDescription = activity.PrsDescription.Expression;
            model.IsPrsPhoneEditable = activity.IsPrsPhoneEditable;
            model.PrsPhone = activity.PrsPhone.Expression;
            model.IsAssignToEditable = activity.IsAssignToEditable;
            model.AssignTo = activity.AssignTo.Expression;
            model.IsCampaignEditable = activity.IsCampaignEditable;
            model.AddToCampaign = activity.AddToCampaign;
            model.Campaign = activity.Campaign.Expression;
        }

        protected override void UpdateActivity(UpdateIdentityByInIdealCrmTaskViewModel model,
            UpdateIdentityByInIdealCrmTask activity)
        {
            activity.SearchKind = model.SearchKind;
            activity.UserName = new WorkflowExpression<string>(model.UserName);
            activity.Password = new WorkflowExpression<string>(model.Password);
            activity.Filter = model.Filter;
            activity.IsIdentityTypeEditable = model.IsIdentityTypeEditable;
            activity.IdentityType = new WorkflowExpression<string>(model.IdentityType);
            activity.IsSubjectEditable = model.IsSubjectEditable;
            activity.Subject = new WorkflowExpression<string>(model.Subject);
            activity.IsTypeEditable = model.IsTypeEditable;
            activity.Type = new WorkflowExpression<string>(model.Type);
            activity.IsCountryEditable = model.IsCountryEditable;
            activity.Country = new WorkflowExpression<string>(model.Country);
            activity.IsProvinceEditable = model.IsProvinceEditable;
            activity.Province = new WorkflowExpression<string>(model.Province);
            activity.IsCityEditable = model.IsCityEditable;
            activity.City = new WorkflowExpression<string>(model.City);
            activity.IsMobileEditable = model.IsMobileEditable;
            activity.Mobile = new WorkflowExpression<string>(model.Mobile);
            activity.IsFirstNameEditable = model.IsFirstNameEditable;
            activity.FirstName = new WorkflowExpression<string>(model.FirstName);
            activity.IsLastNameEditable = model.IsLastNameEditable;
            activity.LastName = new WorkflowExpression<string>(model.LastName);
            activity.IsDescriptionEditable = model.IsDescriptionEditable;
            activity.Description = new WorkflowExpression<string>(model.Description);
            activity.IsAddressEditable = model.IsAddressEditable;
            activity.Address = new WorkflowExpression<string>(model.Address);
            activity.IsGroupEditable = model.IsGroupEditable;
            activity.Group = new WorkflowExpression<string>(model.Group);
            activity.IsPresentationEditable = model.IsPresentationEditable;
            activity.Presentation = new WorkflowExpression<string>(model.Presentation);
            activity.IsNationalIdEditable = model.IsNationalIdEditable;
            activity.NationalId = new WorkflowExpression<string>(model.NationalId);
            activity.IsEconomicCodeEditable = model.IsEconomicCodeEditable;
            activity.EconomicCode = new WorkflowExpression<string>(model.EconomicCode);
            activity.IsRegisterNumberEditable = model.IsRegisterNumberEditable;
            activity.RegisterNumber = new WorkflowExpression<string>(model.RegisterNumber);
            activity.IsPostalCodeEditable = model.IsPostalCodeEditable;
            activity.PostalCode = new WorkflowExpression<string>(model.PostalCode);
            activity.IsPostalBoxEditable = model.IsPostalBoxEditable;
            activity.PostalBox = new WorkflowExpression<string>(model.PostalBox);
            activity.IsCmpEmailEditable = model.IsCmpEmailEditable;
            activity.CmpEmail = new WorkflowExpression<string>(model.CmpEmail);
            activity.IsCmpPhoneEditable = model.IsCmpPhoneEditable;
            activity.CmpPhone = new WorkflowExpression<string>(model.CmpPhone);
            activity.IsJobEditable = model.IsJobEditable;
            activity.Job = new WorkflowExpression<string>(model.Job);
            activity.IsDepartmentEditable = model.IsDepartmentEditable;
            activity.Department = new WorkflowExpression<string>(model.Department);
            activity.IsPrsEmailEditable = model.IsPrsEmailEditable;
            activity.PrsEmail = new WorkflowExpression<string>(model.PrsEmail);
            activity.IsNationalCodeEditable = model.IsNationalCodeEditable;
            activity.NationalCode = new WorkflowExpression<string>(model.NationalCode);
            activity.IsPrsAddressEditable = model.IsPrsAddressEditable;
            activity.PrsAddress = new WorkflowExpression<string>(model.PrsAddress);
            activity.IsPrsDescriptionEditable = model.IsPrsDescriptionEditable;
            activity.PrsDescription = new WorkflowExpression<string>(model.PrsDescription);
            activity.IsPrsPhoneEditable = model.IsPrsPhoneEditable;
            activity.PrsPhone = new WorkflowExpression<string>(model.PrsPhone);
            activity.IsAssignToEditable = model.IsAssignToEditable;
            activity.AssignTo = new WorkflowExpression<string>(model.AssignTo);
            activity.IsCampaignEditable = model.IsCampaignEditable;
            activity.AddToCampaign = model.AddToCampaign;
            activity.Campaign = new WorkflowExpression<string>(model.Campaign);
        }
    }
}