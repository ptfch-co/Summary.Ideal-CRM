namespace Summary.IdealCrm.Workflows.Task.MobileIsExist
{
    using System.ComponentModel.DataAnnotations;

    public class CheckMobileIsExistInIdealCrmTaskViewModel
    {
        [Required]
        public string Mobile { get; set; }
    }
}