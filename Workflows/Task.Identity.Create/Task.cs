namespace Summary.IdealCrm.Workflows.Task.CreateIdentity
{
    using Microsoft.Extensions.Localization;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Core.Workflows.Abstractions.Models;
    using Core.Workflows.Activities;
    using Core.Workflows.Models;
    using Settings;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CreateIdentityInIdealCrmTask : TaskActivity
    {
        private readonly IStringLocalizer<CreateIdentityInIdealCrmTask> T;
        private readonly ILogger<CreateIdentityInIdealCrmTask> _logger;
        private readonly IIdentityService _identity;
        private readonly IdealCrmSettings _options;

        public CreateIdentityInIdealCrmTask(IStringLocalizer<CreateIdentityInIdealCrmTask> t,
            ILogger<CreateIdentityInIdealCrmTask> logger,
            IIdentityService identity,
            IOptions<IdealCrmSettings> options)
        {
            T = t;
            _logger = logger;
            _identity = identity;
            _options = options.Value;
        }

        public override string Name => nameof(CreateIdentityInIdealCrmTask);

        public override LocalizedString DisplayText => T[IdealCrm.Localize.SubjectOfCreateIdentity];

        public override LocalizedString Category => T[IdealCrm.Public.Category];

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext,
            ActivityContext activityContext)
        {
            return Outcomes(T[IdealCrm.Workflows.Done],
                T[IdealCrm.Workflows.Exist]);
        }

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

        public WorkflowExpression<string> Subject
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Type
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Country
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Province
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> City
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Mobile
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> FirstName
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> LastName
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Prefix
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> IdentityType
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Description
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Address
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Group_1
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Presentation
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> NationalId
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> EconomicCode
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> RegisterNumber
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PostalCode
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PostalBox
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CmpEmail
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CmpPhone
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Job
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> Department
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsEmail
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> NationalCode
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsAddress
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsDescription
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> PrsPhone
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> CreatorUser
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> AssignTo
        {
            get => GetProperty(() => new WorkflowExpression<string>());
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
            try
            {
                // Initialization
                var username = workflowContext.GetInputOrDefault(UserName.Expression);
                var password = workflowContext.GetInputOrDefault(Password.Expression);
                var subject = workflowContext.GetInputOrDefault(Subject.Expression);
                var type = workflowContext.GetInputOrDefault(Type.Expression);
                var country = workflowContext.GetInputOrDefault(Country.Expression);
                var province = workflowContext.GetInputOrDefault(Province.Expression);
                var city = workflowContext.GetInputOrDefault(City.Expression);
                var mobile = workflowContext.GetInputOrDefault(Mobile.Expression);
                var firstName = workflowContext.GetInputOrDefault(FirstName.Expression);
                var lastName = workflowContext.GetInputOrDefault(LastName.Expression);
                var prefix = workflowContext.GetInputOrDefault(Prefix.Expression);
                var identityType = workflowContext.GetInputOrDefault(IdentityType.Expression);
                var description = workflowContext.GetInputOrDefault(Description.Expression);
                var address = workflowContext.GetInputOrDefault(Address.Expression);
                var group_1 = workflowContext.GetInputOrDefault(Group_1.Expression);
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
                var creatorUser = workflowContext.GetInputOrDefault(CreatorUser.Expression);
                var campaign = workflowContext.GetInputOrDefault(Campaign.Expression);

                // Initialization to create organization identity
                var org = new CreateOrganizationRequestInfo
                {
                    UserName = username,
                    Password = password,
                    Subject = subject ,
                    Type = type,
                    Country = country,
                    Province = province,
                    City = city,
                    IdentityType = identityType,
                    Description = description,
                    Address = address,
                    Group_1 = group_1,
                    Presentation = presentation,
                    AssignTo = assignTo,
                    CreatorUser = creatorUser,
                    Campaign = campaign,
                    NationalId = nationalId,
                    EconomicCode = economicCode,
                    RegisterNumber = registerNumber,
                    PostalCode = postalCode,
                    PostalBox = postalBox,
                    Email = cmpEmail,
                    Phone = cmpPhone
                };

                // Initialization to create person identity
                var person = new CreatePersonRequestInfo
                {
                    UserName = username,
                    Password = password,
                    LastName =  lastName,
                    FirstName = firstName,
                    Mobile = mobile,
                    Job = job,
                    Department = department,
                    Email = prsEmail,
                    NationalCode = nationalCode,
                    Address = prsAddress,
                    Description = prsDescription,
                    Phone = prsPhone,
                    CreatorUser = creatorUser
                };

                // Send request to the server
                var response = await _identity.CreateIdentityAsync(
                    org,
                    person
                );

                // Adding identity information to the workflow
                workflowContext.Input[$"{prefix}.Organization.Id"] = response.OrganizationId;
                workflowContext.Input[$"{prefix}.Person.Id"] = response.PersonId;

                // Successful request
                return Outcomes(IdealCrm.Workflows.Done);
            }
            catch (PersonIsExistException)
            {
                // The information is duplicate
                return Outcomes(IdealCrm.Workflows.Exist);
            }
            catch
            {
                throw;
            }
        }
    }
}