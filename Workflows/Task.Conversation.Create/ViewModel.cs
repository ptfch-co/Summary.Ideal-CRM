namespace Summary.IdealCrm.Workflows.Task.Conversation.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreateConversationInIdealCrmTaskViewModel : BaseTaskActivityViewModel
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string Person { get; set; }
        [Required]
        public string Project { get; set; }
        public string Date { get; set; }
        [Required]
        public string Type { get; set; }
        public string Desc { get; set; }
        [Required]
        public string CreatorUser { get; set; }
        [Required]
        public string ReferUser { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Priority { get; set; }
        public string RemindDate { get; set; }
        public string AlarmDate { get; set; }
        public string RemindTime { get; set; }
        public string IsRemind { get; set; }
        public string IsBookMark { get; set; }
        public string DoingTime { get; set; }
        [Required]
        public string Output { get; set; }
    }
}