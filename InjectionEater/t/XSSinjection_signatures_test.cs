using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_signatures_test
    {
        [Test]
        public void XSSinject_siganture_test_founded()
        {
            int xssTestIndex = 0;

            string[] xssTests = new string[] {
                @"<script>alert('vulnerable!')</script>",
                @"<img src=" + '"' + @"javascript:alert('vulnerable!');" + '"' + ">",
                @"<img src=onmouseover=" + '"' + @"alert('vulnerable!');" + '"' + ">",
            };

            foreach (string xss in xssTests)
            {
                xssTestIndex += 1;
                Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), String.Format("xss #{0} <-- fail", xssTestIndex));
            }
        }

        [Test]
        public void XSSinject_siganture_test_notFounded()
        {
            int xssTestIndex = 0;

            string[] xssTests = new string[] {
                @"<img src=" + '"' + @"path/image.jpeg" + '"' + ">",
            };

            foreach (string xss in xssTests)
            {
                xssTestIndex += 1;
                Assert.That(String.IsNullOrEmpty(XSSsignatures.Eat(xss)), String.Format("xss #{0} <-- fail", xssTestIndex));
            }
        }
    }
}
