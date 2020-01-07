using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_obfuscate_test
    {
        [Test]
        public void XSSinject_obfuscate_test_case_founded()
        {
            string xss = @"<img src=" + '"' + @"jAvAsCrIPt:alert('xss');" + '"' + ">";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss case fail");
        }
    }
}
