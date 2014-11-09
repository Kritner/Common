
using Kritner.Common.DateExtensions.Exceptions;
using System;
namespace Kritner.Common.DateExtensions
{

    /// <summary>
    /// Date range class - contains a start and end DateTime
    /// </summary>
    public class DateRange
    {

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public TimeSpan DateRangeSpan { get { return EndDate - StartDate; } }

        private const string _DateFormat = "dd/MM/yyyy";

        /// <summary>
        /// Constructor - Create a DateRange object
        /// </summary>
        /// <param name="startDate">Start date of the date range</param>
        /// <param name="endDate">End date of the date range</param>
        public DateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new StartDateOccursAfterEndDateException(string.Format("Start Date of {0} must occur prior to End Date of {1}", startDate, endDate));

            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        /// <summary>
        /// Returns a new DateRange object with the specified startDate and endDate 
        /// (rather than changing the current values, just create and return a new object)
        /// </summary>
        /// <param name="startDate">Start date of the date range</param>
        /// <param name="endDate">End date of the date range</param>
        /// <returns>DateRange</returns>
        public DateRange GetNewDateRange(DateTime startDate, DateTime endDate)
        {
            return new DateRange(startDate, endDate);
        }

        /// <summary>
        /// Display the string representation of the DateRange
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", this.StartDate.ToString(_DateFormat), EndDate.ToString(_DateFormat));
        }

    }
}
