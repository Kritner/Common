
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

    }
}
