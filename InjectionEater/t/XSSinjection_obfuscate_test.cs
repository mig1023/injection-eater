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

        [Test]
        public void XSSinject_obfuscate_test_default_founded()
        {
            string xss = @"<IMG SRC =# onmouseover=alert('xxs')>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss def1 fail");
        }

        [Test]
        public void XSSinject_obfuscate_test_default_by_empty_founded()
        {
            string xss = @"<IMG SRC= onmouseover=alert('xxs')>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss def2 fail");
        }

        [Test]
        public void XSSinject_obfuscate_test_default_by_entirely_founded()
        {
            string xss = @"<IMG onmouseover=alert('xxs')>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss def3 fail");
        }

        [Test]
        public void XSSinject_obfuscate_test_alert_encoded_founded()
        {
            string xss = @"<img src = x onerror=" + '"' + "&#0000106&#0000097&#0000118&#0000097" +
                "&#0000115&#0000099&#0000114&#0000105&#0000112&#0000116&#0000058&#0000097&#0000108" + 
                "&#0000101&#0000114&#0000116&#0000040&#0000039&#0000088&#0000083&#0000083&#0000039" +
                "&#0000041" + '"' + ">";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(xss)), "xss def3 fail");
        }
    }
}
