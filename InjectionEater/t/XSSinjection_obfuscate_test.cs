using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_obfuscate_test
    {
        [Test]
        public void XSSinject_obfuscate_test_founded() =>
            Assert.IsNotEmpty(XSSinjection.Eat(@"<img src=" + '"' + "jAvAsCrIPt:alert('xss');" + '"' + ">"));
    }
}
