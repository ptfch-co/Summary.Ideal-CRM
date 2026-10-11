namespace Summary.IdealCrm
{
    public class Ideal : IdealCrm { }

    public class IdealCrm
    {
        internal class Features
        {
            internal const string IdealCrm = "Summary.IdealCrm";
            internal const string CreateIdentity = "Summary.IdealCrm.CreateIdentityTask";
            internal const string GetPersonDetailsBy = "Summary.IdealCrm.Task.GetPerosnDetailsBy";
            internal const string UpdateProjectBy = "Summary.IdealCrm.Task.UpdateProjectBy";
            internal const string GetProjectDetailsBy = "Summary.IdealCrm.Task.GetProjectDetails";
            internal const string UpdateIdentityBy = "Summary.IdealCrm.Task.Identity.UpdateBy";
            internal const string CUIdentityEvent = "Summary.Ideal.CRM.Workflows.Event.Identity.CU";
        }

        internal class Workflows
        {
            internal const string Done = "Done";
            internal const string Exist = "Exist";
            internal const string NotExist = "Not Exist";
            internal const string Failed = "Failed";
            internal const string Iterate = "Iterate";
        }

        internal class Public
        {
            internal const string Category = "Ideal CRM";
        }

        public class Localize
        {
            public const string SubjectOfIdealCrm = "سی آر ام ایده آل";
            public const string DescriptionOfIdealCrm = "مجموعه از رخداد و تسک‌ها جهت ارتباط با سی آر ام ایده آل.";
            public const string SubjectOfCheckMobileIsExist = "اعتبارسنجی پروفایل مشتریان حقیقی و حقوقی";
            public const string DescriptionOfCheckMobileIsExist = "فعالیتی جهت بررسی اینکه آیا پروفایل مشتری حقیقی و حقوقی در CRM ایده آل تعریف شده است یا خیر.";
            public const string SubjectOfCreateIdentity = " ایجاد پروفایل هویت(حقیقی، حقوقی)";
            public const string DescriptionOfCreateIdentity = "فعالیتی جهت ایجاد پروفایل هویت(حقیقی، حقوقی) در سی آر ام ایده آل.";
            public const string SubjectOfCreateProject = "ایجاد پروژه";
            public const string DescriptionOfCreateProject = "فعالیتی جهت ایجاد پروژه در سی آر ام ایده آل.";
            public const string SubjectOfCreateConversation = "ایجاد رویداد پروژه";
            public const string DescriptionOfCreateConversation = "فعالیتی جهت ایجاد رویدادِ مرتبط با پروژه در سی آر ام ایده آل.";
            public const string SubjectOfGetPersonDetailsBy = "واکشی اطلاعات پروفایل مشتری";
            public const string DescriptionOfGetPersonDetailsBy = "فعالیتی است جهت واکشی اطلاعات پروفایل مشتری در CRM ایده آل و افزودن آن به گردش کار.";
            public const string SubjectOfUpdateProjectBy = "بروزرسانی پروژه";
            public const string DescriptionOfUpdateProjectBy = "فعالیتی جهت بروزرسانی پروژه در سی آر ام ایده آل.";
            public const string SubjectOfGetProjectDetailsBy = "دریافت اطلاعات پروژه";
            public const string DescriptionOfGetProjectDetailsBy = "فعالیتی جهت دریافت اطلاعات پروژه در سی آر ام ایده آل و افزودن آن به گردش کار.";
            public const string SubjectOfCreateQuote = "ایجاد پیش فاکتور";
            public const string DescriptionOfCreateQuote = "فعالیتی جهت ایجاد پیش فاکتور در سی آر ام ایده آل.";
            public const string SubjectOfUpdateIdentityBy = "بروزرسانی هویت حقیقی و حقوقی";
            public const string DescriptionOfUpdateIdentityBy = "فعالیتی جهت بروزرسانی هویت‌های حقیقی و حقوقی  در CRM ایده آل.";
            public const string SubjectOfCUIdentityEvent = "رویداد ایجاد و ویرایش پروفایل مخاطب";
            public const string DescriptionOfCUIdentityEvent = "این رویداد زمانی فراخوانی میشود که در CRM ایده آل یک مخاطب جدید ایجاد یا ویرایش شود.";
        }
    }
}