namespace Summary.IdealCrm.Workflows.Task.Project.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreateProjectInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Title { get; set; }
        public string InquiryNumber { get; set; }
        public string Desc { get; set; }
        public string StartDate { get; set; }
        [Required]
        public string StarterUser { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        public string CnvsStatusGroup { get; set; }
        public string PostFix { get; set; }
        public string RemindDateTime { get; set; }
        public string IsTicket { get; set; }
        [Required]
        public string CmpPresentation { get; set; }
        [Required]
        public string IsFinished { get; set; }
        public string CreatorUser { get; set; }
        public string Campaign { get; set; }
        [Required]
        public string Output { get; set; }
    }
}