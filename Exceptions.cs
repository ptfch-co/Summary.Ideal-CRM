namespace Summary.IdealCrm
{
    using System;
    using Core.Workflows;

    public class PersonIsExistException : Exception
    {
        public PersonIsExistException(string message) : base(message) { }
    }

    public class ThrowExceptionIf
    {
        public static void UnknownMessage(string error)
        {
            if (error.Contains("نام کاربری یا رمز عبور اشتباه می باشد")) throw new WorkflowException(
                "نام کاربری یا رمز عبور اشتباه می باشد.",
                null,
                null,
                "کاربر گرامی، نام‌کاربری یا رمز عبوری که در تنظیمات افزونه‌ی ایده‌آل وارد کرده‌اید نادرست است. لطفاً از طریق ثبت تیکت در مجموعه‌ی ایده‌آل، نام‌کاربری و رمز عبور صحیح وب‌سرویس را دریافت کرده و سپس تنظیمات افزونه را اصلاح نمایید.",
                Level.Information
            );

            throw new WorkflowException(
                error
            );
        }
    }
}