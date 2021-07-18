using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_signatures_test
    {
        [Test]
        public void XSSinject_siganture_test_banal_founded() =>
            Assert.IsNotEmpty(XSSsignatures.Eat(@"<script>alert('vulnerable!')</script>"));

        [Test]
        public void XSSinject_siganture_test_img_founded() =>
            Assert.IsNotEmpty(XSSsignatures.Eat(@"<img src=" + '"' + @"javascript:alert('vulnerable!');" + '"' + ">"));

        [Test]
        public void XSSinject_siganture_test_onmousemove_founded() =>
            Assert.IsNotEmpty(XSSsignatures.Eat(@"<img src=onmouseover=" + '"' + @"alert('vulnerable!');" + '"' + ">"));
    }
}
