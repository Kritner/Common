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
    class OppositeTests
    {
        [Test]
        public void Test_1()
        {
            Assert.AreEqual(-1, Opposite.ReturnOpposite(1));
        }
    }
}
