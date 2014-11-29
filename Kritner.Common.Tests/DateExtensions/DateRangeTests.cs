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

        [TestMethod]
        public void DateRange_TimeSpanObjectReturns10SecondDifferenceOnDates()
        {
            // Arrange
            int secondsToAdd = 10;
            DateTime startDate = new DateTime(2014, 1, 1, 1, 1, 1);
            DateTime endDate = startDate.AddSeconds(secondsToAdd);

            // Act
            var dateRange = new DateRange(startDate, endDate);

            // Assert
            Assert.AreEqual(secondsToAdd, dateRange.DateRangeSpan.TotalSeconds);
        }

        [TestMethod]
        public void DateRange_GetNewDateRangeReturnsNewDateRange()
        {
            // Arrange
            DateTime originalStartDate = new DateTime(2013, 1, 1);
            DateTime originalEndDate = new DateTime(2014, 1, 1);
            DateTime newStartDate = new DateTime(2015, 1, 1);
            DateTime newEndDate = new DateTime(2016, 1, 1);

            var newExpectedDateRange = new DateRange(newStartDate, newEndDate);

            // Act
            var originalDateRange = new DateRange(originalStartDate, originalEndDate);
            var newDateRange = originalDateRange.GetNewDateRange(newStartDate, newEndDate);

            // Assert
            Assert.AreEqual(newExpectedDateRange.DateRangeSpan, newDateRange.DateRangeSpan);
        }

        [TestMethod]
        public void DateRange_ToString()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1);
            DateTime endDate = new DateTime(2014, 1, 2);

            string dateRangeString = string.Format("{0} - {1}", startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"));

            // Act
            var dateRange = new DateRange(startDate, endDate);

            // Assert
            Assert.AreEqual(dateRangeString, dateRange.ToString());
        }

        [TestMethod]
        public void DateRange_IsWithinRangeFalseWhenOutsideOfRange_Date()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime testDate = new DateTime(2014, 1, 1, 5, 1, 0);

            // Act
            DateRange dr = new DateRange(startDate, endDate);
            bool isWithinRange = dr.IsWithinRange(testDate);

            // Assert
            Assert.IsFalse(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeTrueWhenEqualToStart_Date()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime testDate = startDate;

            // Act
            DateRange dr = new DateRange(startDate, endDate);
            bool isWithinRange = dr.IsWithinRange(testDate);

            // Assert
            Assert.IsTrue(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeTrueWhenEqualToEnd_Date()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime testDate = endDate;

            // Act
            DateRange dr = new DateRange(startDate, endDate);
            bool isWithinRange = dr.IsWithinRange(testDate);

            // Assert
            Assert.IsTrue(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeTrueWhenWithinStartAndEnd_Date()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime testDate = new DateTime(2014, 5, 5);

            // Act
            DateRange dr = new DateRange(startDate, endDate);
            bool isWithinRange = dr.IsWithinRange(testDate);

            // Assert
            Assert.IsTrue(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeFalseWhenCheckingStartRangeOutsideStartRange()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime checkStartDate = new DateTime(2014, 1, 1, 5, 1, 0);
            DateTime checkEndDate = new DateTime(2014, 5, 5);

            // Act
            DateRange dateRange = new DateRange(startDate, endDate);
            DateRange checkDateRange = new DateRange(checkStartDate, checkEndDate);

            bool isWithinRange = dateRange.IsWithinRange(checkDateRange);

            // Assert
            Assert.IsFalse(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeFalseWhenCheckingEndRangeOutsideEndRange()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime checkStartDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime checkEndDate = new DateTime(2015, 1, 1, 5, 1, 2);

            // Act
            DateRange dateRange = new DateRange(startDate, endDate);
            DateRange checkDateRange = new DateRange(checkStartDate, checkEndDate);

            bool isWithinRange = dateRange.IsWithinRange(checkDateRange);

            // Assert
            Assert.IsFalse(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeFalseWhenCheckingRangeCompletelyOutsideDateRange()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime checkStartDate = new DateTime(2013, 1, 1, 5, 1, 1);
            DateTime checkEndDate = new DateTime(2016, 1, 1, 5, 1, 2);

            // Act
            DateRange dateRange = new DateRange(startDate, endDate);
            DateRange checkDateRange = new DateRange(checkStartDate, checkEndDate);

            bool isWithinRange = dateRange.IsWithinRange(checkDateRange);

            // Assert
            Assert.IsFalse(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeTrueWhenDateRangesEqual()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime checkStartDate = startDate;
            DateTime checkEndDate = endDate;

            // Act
            DateRange dateRange = new DateRange(startDate, endDate);
            DateRange checkDateRange = new DateRange(checkStartDate, checkEndDate);

            bool isWithinRange = dateRange.IsWithinRange(checkDateRange);

            // Assert
            Assert.IsTrue(isWithinRange);
        }

        [TestMethod]
        public void DateRange_IsWithinRangeTrueWhenDateRangesWithinDateRange()
        {
            // Arrange
            DateTime startDate = new DateTime(2014, 1, 1, 5, 1, 1);
            DateTime endDate = new DateTime(2015, 1, 1, 5, 1, 1);

            DateTime checkStartDate = startDate.AddSeconds(1);
            DateTime checkEndDate = endDate.AddSeconds(-1);

            // Act
            DateRange dateRange = new DateRange(startDate, endDate);
            DateRange checkDateRange = new DateRange(checkStartDate, checkEndDate);

            bool isWithinRange = dateRange.IsWithinRange(checkDateRange);

            // Assert
            Assert.IsTrue(isWithinRange);
        }

    }
}
