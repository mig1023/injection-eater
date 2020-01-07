using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_obfuscate_test
    {
        [Test]
        public void XSSinject_obfuscate_test_founded()
        {
            int xssTestIndex = 0;

            string[] allXSS = new string[] {
                @"<img src=" + '"' + @"jAvAsCrIPt:alert('xss');" + '"' + ">",
            };

            foreach (string xss in allXSS)
            {
                xssTestIndex += 1;
                Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), String.Format("xss #{0} <-- fail", xssTestIndex));
            }
        }
    }
}
