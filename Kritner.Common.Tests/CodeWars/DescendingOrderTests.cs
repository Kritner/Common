using Kritner.Common.CodeWars;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common.Tests.CodeWars
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test0()
        {
            Assert.AreEqual(0, DescendingOrderKata.DescendingOrder(0));
        }

        [Test]
        public void NegativeThrows()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => DescendingOrderKata.DescendingOrder(-1));
        }

        [Test]
        [TestCase(12345, 54321)]
        [TestCase(11112, 21111)]
        public void Test1(int provided, int expectation)
        {
            Assert.AreEqual(expectation, DescendingOrderKata.DescendingOrder(provided));
        }
    }
}
