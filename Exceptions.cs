namespace Summary.IdealCrm
{
    using System;

    public class PersonIsExistException : Exception
    {
        public PersonIsExistException(string message) : base(message) { }
    }
}