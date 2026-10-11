using Core.Modules.Manifest;
using Summary.IdealCrm;

[assembly: Feature(
    Id = IdealCrm.Features.IdealCrm,
    Name = IdealCrm.Localize.SubjectOfIdealCrm,
    Description =IdealCrm.Localize.DescriptionOfIdealCrm,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { "Core.Workflows" },
    Version = "1.13.0"
)]

[assembly: Feature(
    Id = IdealCrm.Features.CreateIdentity,
    Name = IdealCrm.Localize.SubjectOfCreateIdentity,
    Description =IdealCrm.Localize.DescriptionOfCreateIdentity,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.3.1"
)]

[assembly: Feature(
    Id = IdealCrm.Features.GetPersonDetailsBy,
    Name = IdealCrm.Localize.SubjectOfGetPersonDetailsBy,
    Description =IdealCrm.Localize.DescriptionOfGetPersonDetailsBy,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.1.0"
)]

[assembly: Feature(
    Id = IdealCrm.Features.UpdateProjectBy,
    Name = IdealCrm.Localize.SubjectOfUpdateProjectBy,
    Description =IdealCrm.Localize.DescriptionOfUpdateProjectBy,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.0.0"
)]

[assembly: Feature(
    Id = IdealCrm.Features.GetProjectDetailsBy,
    Name = IdealCrm.Localize.SubjectOfGetProjectDetailsBy,
    Description =IdealCrm.Localize.DescriptionOfGetProjectDetailsBy,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.1.1"
)]

[assembly: Feature(
    Id = IdealCrm.Features.CreateQuote,
    Name = IdealCrm.Localize.SubjectOfCreateQuote,
    Description =IdealCrm.Localize.DescriptionOfCreateQuote,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.0.0"
)]

[assembly: Feature(
    Id = IdealCrm.Features.UpdateIdentityBy,
    Name = IdealCrm.Localize.SubjectOfUpdateIdentityBy,
    Description = IdealCrm.Localize.DescriptionOfUpdateIdentityBy,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.0.0"
)]

[assembly: Feature(
    Id = IdealCrm.Features.CUIdentityEvent,
    Name = IdealCrm.Localize.SubjectOfCUIdentityEvent,
    Description = IdealCrm.Localize.DescriptionOfCUIdentityEvent,
    Category = IdealCrm.Public.Category,
    Dependencies = new[] { IdealCrm.Features.IdealCrm },
    Version = "1.0.0"
)]