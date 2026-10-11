namespace Summary.IdealCrm.Workflows.Task.Identity.UpdateBy
{
    using Microsoft.Extensions.Localization;
    using Core.Mvc.Utilities;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UpdateIdentityByInIdealCrmTask : BaseTaskActivity
    {
        private readonly IStringLocalizer<UpdateIdentityByInIdealCrmTask> T;
        private readonly IIdentityService _identity;

        public UpdateIdentityByInIdealCrmTask(IStringLocalizer<UpdateIdentityByInIdealCrmTask> t,
            IIdentityService identity)
        {
            T = t;
            _identity = identity;
        }

        public override string Name => nameof(UpdateIdentityByInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfCreateIdentity];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done]);
        }

        public IdentitySearchKind SearchKind
        {
            get => GetProperty(() => default(IdentitySearchKind));
            set => SetProperty(value);
        }

        public string Filter
        {
            get => GetProperty(() => String.Empty );
            set => SetProperty(value);
        }

        public bool IsSubjectEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Subject
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsTypeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Type
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsCountryEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Country
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsProvinceEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Province
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsCityEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> City
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsMobileEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Mobile
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsFirstNameEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> FirstName
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsLastNameEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> LastName
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsIdentityTypeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IdentityType
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsDescriptionEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Description
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsAddressEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Address
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsGroupEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Group
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPresentationEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Presentation
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsNationalIdEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> NationalId
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsEconomicCodeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> EconomicCode
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsRegisterNumberEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> RegisterNumber
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPostalCodeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PostalCode
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPostalBoxEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PostalBox
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsCmpEmailEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CmpEmail
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsCmpPhoneEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CmpPhone
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsJobEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Job
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsDepartmentEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Department
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPrsEmailEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsEmail
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsNationalCodeEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> NationalCode
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPrsAddressEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsAddress
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPrsDescriptionEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsDescription
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsPrsPhoneEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsPhone
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsAssignToEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> AssignTo
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public bool IsCampaignEditable
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public bool AddToCampaign
        {
            get => GetProperty(() => false);
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Campaign
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {

            var userName = workflowContext.GetInputOrDefault(UserName.Expression);
            var password = workflowContext.GetInputOrDefault(Password.Expression);
            var subject = workflowContext.GetInputOrDefault(Subject.Expression);
            var type = workflowContext.GetInputOrDefault(Type.Expression);
            var country = workflowContext.GetInputOrDefault(Country.Expression);
            var province = workflowContext.GetInputOrDefault(Province.Expression);
            var city = workflowContext.GetInputOrDefault(City.Expression);
            var mobile = workflowContext.GetInputOrDefault(Mobile.Expression);
            var firstName = workflowContext.GetInputOrDefault(FirstName.Expression);
            var lastName = workflowContext.GetInputOrDefault(LastName.Expression);
            var identityType = workflowContext.GetInputOrDefault(IdentityType.Expression);
            var description = workflowContext.GetInputOrDefault(Description.Expression);
            var address = workflowContext.GetInputOrDefault(Address.Expression);
            var group = workflowContext.GetInputOrDefault(Group.Expression);
            var presentation = workflowContext.GetInputOrDefault(Presentation.Expression);
            var nationalId = workflowContext.GetInputOrDefault(NationalId.Expression);
            var economicCode = workflowContext.GetInputOrDefault(EconomicCode.Expression);
            var registerNumber = workflowContext.GetInputOrDefault(RegisterNumber.Expression);
            var postalCode = workflowContext.GetInputOrDefault(PostalCode.Expression);
            var postalBox = workflowContext.GetInputOrDefault(PostalBox.Expression);
            var cmpEmail = workflowContext.GetInputOrDefault(CmpEmail.Expression);
            var cmpPhone = workflowContext.GetInputOrDefault(CmpPhone.Expression);
            var job = workflowContext.GetInputOrDefault(Job.Expression);
            var department = workflowContext.GetInputOrDefault(Department.Expression);
            var prsEmail = workflowContext.GetInputOrDefault(PrsEmail.Expression);
            var nationalCode = workflowContext.GetInputOrDefault(NationalCode.Expression);
            var prsAddress = workflowContext.GetInputOrDefault(PrsAddress.Expression);
            var prsDescription = workflowContext.GetInputOrDefault(PrsDescription.Expression);
            var prsPhone = workflowContext.GetInputOrDefault(PrsPhone.Expression);
            var assignTo = workflowContext.GetInputOrDefault(AssignTo.Expression);
            var campaign = workflowContext.GetInputOrDefault(Campaign.Expression);
            var filter = workflowContext.GetInputOrDefault(Filter);

            await _identity.UpdateAsync(
                SearchKind,
                userName,
                password,
                filter,
                IsIdentityTypeEditable,
                identityType,
                IsSubjectEditable,
                subject,
                IsTypeEditable,
                type,
                IsCountryEditable,
                country,
                IsProvinceEditable,
                province,
                IsCityEditable,
                city,
                IsMobileEditable,
                mobile,
                IsFirstNameEditable,
                firstName,
                IsLastNameEditable,
                lastName,
                IsDescriptionEditable,
                description,
                IsAddressEditable,
                address,
                IsGroupEditable,
                group,
                IsPresentationEditable,
                presentation,
                IsNationalIdEditable,
                nationalId,
                IsEconomicCodeEditable,
                economicCode,
                IsRegisterNumberEditable,
                registerNumber,
                IsPostalCodeEditable,
                postalCode,
                IsPostalBoxEditable,
                postalBox,
                IsCmpEmailEditable,
                cmpEmail,
                IsCmpPhoneEditable,
                cmpPhone,
                IsJobEditable,
                job,
                IsDepartmentEditable,
                department,
                IsPrsEmailEditable,
                prsEmail,
                IsNationalCodeEditable,
                nationalCode,
                IsPrsAddressEditable,
                prsAddress,
                IsPrsDescriptionEditable,
                prsDescription,
                IsPrsPhoneEditable,
                prsPhone,
                IsAssignToEditable,
                assignTo,
                IsCampaignEditable,
                AddToCampaign,
                campaign
            );

            return Outcomes(IdealCrm.Workflows.Done);
        }
    }
}