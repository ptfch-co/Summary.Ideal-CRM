namespace Summary.IdealCrm.Workflows.Task.Project.UpdateBy
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateProjectByInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        [Required]
        public string Filter { get; set; }
        public bool TitleEditable { get; set; }
        public string Title { get; set; }
        public bool DescEditable { get; set; }
        public string Desc { get; set; }
        public bool StartDateEditable { get; set; }
        public string StartDate { get; set; }
        public bool StarterUserEditable { get; set; }
        public string StarterUser { get; set; }
        public bool GradeEditable { get; set; }
        public string Grade { get; set; }
        public bool PriorityEditable { get; set; }
        public string Priority { get; set; }
        public bool GroupEditable { get; set; }
        public string Group { get; set; }
        public bool CnvsStatusGroupEditable { get; set; }
        public string CnvsStatusGroup { get; set; }
        public bool PostFixEditable { get; set; }
        public string PostFix { get; set; }
        public bool RemindDateTimeEditable { get; set; }
        public string RemindDateTime { get; set; }
        public bool CmpPresentationEditable { get; set; }
        public string CmpPresentation { get; set; }
        public bool IsFinishedEditable { get; set; }
        public string IsFinished { get; set; }
    }
}