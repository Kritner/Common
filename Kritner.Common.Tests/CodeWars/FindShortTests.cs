using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kritner.Common.CodeWars.Tests
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(3, FindShort.FindShortestWordLength("bitcoin take over the world maybe who knows perhaps"));
            Assert.AreEqual(3, FindShort.FindShortestWordLength("turns out random test cases are easier than writing out basic ones"));
        }
    }
}