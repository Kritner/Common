
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

        public DateRange(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

    }
}
