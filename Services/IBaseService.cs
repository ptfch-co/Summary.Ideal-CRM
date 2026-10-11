namespace Summary.IdealCrm
{
    public abstract class BaseService
    {
        internal const string MOBILE_REGEX_FORMAT = @"^(\+\+98|\+98|09898|9898|098|98|0)";
        internal const string TELPHONE_REGEX_FORMAT  = @"\d{8}$";
    }
}