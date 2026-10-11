namespace Summary.IdealCrm.Workflows.Task.Person.Details.GetBy
{
    using System.ComponentModel.DataAnnotations;

    public class GetPersonDetailsByInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        [Required]
        public string Filter { get; set; }
        [Required]
        public PersonSearchKind SearchKind { get; set; }
        [Required]
        public string Output { get; set; }
    }
}