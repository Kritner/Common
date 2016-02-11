using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kritner.Common.TestHelpers
{
    
    /// <summary>
    /// Tests for ClassPropertyGetterSetters
    /// </summary>
    [TestClass]
    public class ClassPropertyGetterSettersTests
    {

        /// <summary>
        /// Tests a bool property is changed in a class
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_BoolPropertyChanged()
        {
            FooTest f = new FooTest(false);
            FooTest fChanged = new FooTest(false);
            fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(fChanged);

            Assert.AreNotEqual(f.TestBool, fChanged.TestBool, "TestBool");
        }
    }

    public class FooTest
    {
        public bool TestBool { get; set; }

        public FooTest(bool testBool)
        {
            this.TestBool = testBool;
        }
    }
}
