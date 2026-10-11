using System.Diagnostics;
namespace Summary.IdealCrm.Workflows.Task.MobileIsExist
{
    using Core.Workflows.Display;

    public class CheckMobileIsExistInIdealCrmTaskDisplay : ActivityDisplayDriver<CheckMobileIsExistInIdealCrmTask,
        CheckMobileIsExistInIdealCrmTaskViewModel>
    {
        protected override void EditActivity(CheckMobileIsExistInIdealCrmTask activity, 
            CheckMobileIsExistInIdealCrmTaskViewModel model)
        {
            model.Mobile = activity.Mobile;
        }

        protected override void UpdateActivity(CheckMobileIsExistInIdealCrmTaskViewModel model, 
            CheckMobileIsExistInIdealCrmTask activity)
        {
            activity.Mobile = model.Mobile;
        }
    }
}