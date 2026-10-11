namespace Summary.IdealCrm.Workflows.Task.Project.Details.GetBy
{
    using System.ComponentModel.DataAnnotations;

    public class GetProjectDetailsByInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        [Required]
        public string Filter { get; set; }
        [Required]
        public ProjectSearchKind SearchKind { get; set; }
        [Required]
        public string Output { get; set; }
    }
}