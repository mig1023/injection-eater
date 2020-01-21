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
            string xss = @"<img src=jAvAsCrIPt:alert('xss');>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss case fail");
        }

        [Test]
        public void XSSinject_obfuscate_test_url_founded()
        {
            string xss = @"%3Cimg%20src%3Djavascript%3Aalert%28%27xss%27%29%3B%3E";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss urlcode fail");
        }
    }
}
