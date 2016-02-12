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
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);
            
            Assert.AreNotEqual(f.TestBool, fChanged.TestBool);
        }

        /// <summary>
        /// Tests a string property is changed in a class
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_StringPropertyChanged()
        {
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);

            Assert.AreNotEqual(f.TestString, fChanged.TestString);
        }

        /// <summary>
        /// Tests a DateTime property is changed in a class
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_DateTimePropertyChanged()
        {
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);

            Assert.AreNotEqual(f.TestDateTime, fChanged.TestDateTime);
        }

        /// <summary>
        /// Tests a int property is changed in a class
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_IntPrivateSetterHasNoPropertyChanged()
        {
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);

            Assert.AreEqual(f.TestInt, fChanged.TestInt);
        }

        /// <summary>
        /// Tests a Double property is changed in a class
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_DoublePrivateSetterHasNoPropertyChanged()
        {
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);

            Assert.AreEqual(f.TestDouble, fChanged.TestDouble);
        }

        /// <summary>
        /// Tests a Decimal property is changed in a class
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_DecimalPrivateSetterHasNoPropertyChanged()
        {
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);

            Assert.AreEqual(f.TestDecimal, fChanged.TestDecimal);
        }


        /// <summary>
        /// Tests a bool property is not changed in a class when it has a private setter
        /// </summary>
        [TestMethod]
        public void ClassPropertyGetterSettersTests_TestClassProperties_BoolPropertyNotChangedWithPrivateSetter()
        {
            FooTest f = new FooTest();
            FooTest fChanged = ClassPropertyGetterSetters.TestClassProperties<FooTest>(f);

            Assert.AreEqual(f.TestBoolWithPrivateSetter, fChanged.TestBoolWithPrivateSetter);
        }

    }

    internal class FooTest
    {
        public bool TestBool { get; set; }
        public string TestString { get; set; }
        public DateTime TestDateTime { get; set; }
        public int TestInt { get; set; }
        public double TestDouble { get; set; }
        public decimal TestDecimal { get; set; }
        public bool TestBoolWithPrivateSetter { get; private set; }
        private bool TestBoolPrivate { get; set; }

        public FooTest()
        {
            this.TestBool = false;
            this.TestBoolPrivate = false;
            this.TestBoolWithPrivateSetter = false;
            this.TestString = "test";
            this.TestDateTime = DateTime.MinValue;
        }
    }
}
