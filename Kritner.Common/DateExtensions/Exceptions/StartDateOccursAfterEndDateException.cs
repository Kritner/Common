using System;

namespace Kritner.Common.DateExtensions.Exceptions
{

    /// <summary>
    /// Exception is created when the Start date occurs after the End Date
    /// </summary>
    /// <example>
    /// StartDate - 2014/01/01
    /// EndDate - 2013/01/01
    /// </example>
    public class StartDateOccursAfterEndDateException : Exception
    {
        public StartDateOccursAfterEndDateException()
            : base() { }

        public StartDateOccursAfterEndDateException(string message)
            : base(message) { }

        public StartDateOccursAfterEndDateException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
