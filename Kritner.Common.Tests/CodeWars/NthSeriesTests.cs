using Kritner.Common.CodeWars;
using NUnit.Framework;
using System;

namespace Kritner.Common.Tests.CodeWars
{
    [TestFixture]
    public class NthSeriesTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("0.00", NthSeries.seriesSum(0));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("1.77", NthSeries.seriesSum(9));
        }
        [Test]
        [TestCase(2, "1.25")]
        [TestCase(5, "1.57")]
        public void Test3(int n, string expectedReturn)
        {
            Assert.AreEqual(expectedReturn, NthSeries.seriesSum(n));
        }
    }
}
