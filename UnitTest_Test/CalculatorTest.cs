using NUnit.Framework;
using System;
using UnitTest;

namespace UnitTest_Test
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void Add_Test()
        {
            Calculator cal = new Calculator();
            int add_Result = cal.Add(3, 5);
            Assert.That(add_Result, Is.EqualTo(8));
        }

        [Test]
        public void Sub_Test()
        {
            Calculator cal = new Calculator();
            int sub_Result = cal.Sub(3, 5);
            Assert.That(sub_Result, Is.EqualTo(8));
        }
    }
}
