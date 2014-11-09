using Kritner.Common.DateExtensions;
using Kritner.Common.DateExtensions.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Kritner.Common.Tests.DateExtensions
{

    /// <summary>
    /// Unit tests for the DateRange class
    /// </summary>
    [TestClass]
    public class DateRangeTests
    {

        [TestMethod]
        public void DateRange_ConstructorArgumentBecomesPropertyStartDate()
        {
            // Arrange
            DateTime startDate = new DateTime(2013, 1, 1);
            DateTime endDate = new DateTime(2014, 1, 1);

            // Act
            var dateRange = new DateRange(startDate, endDate);

            // Assert
            Assert.AreEqual(startDate, dateRange.StartDate);
        }

        [TestMethod]
        public void DateRange_ConstructorArgumentComesPropertyEndDate()
        {
            // Arrange
            DateTime startDate = new DateTime(2013, 1, 1);
            DateTime endDate = new DateTime(2014, 1, 1);

            // Act
            var dateRange = new DateRange(startDate, endDate);

            // Assert
            Assert.AreEqual(endDate, dateRange.EndDate);
        }

        [TestMethod]
        [ExpectedException(typeof(StartDateOccursAfterEndDateException))]
        public void DateRange_WhenStartDateAfterEndDateExceptionThrown()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1);
            DateTime endDate = new DateTime(2013, 1, 1);

            // Act
            var dateRange = new DateRange(startDate, endDate);
        }

    }
}
