using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_signatures_test
    {
        [Test]
        public void XSSinject_siganture_test_banal_founded()
        {
            string sql = @"<script>alert('vulnerable!')</script>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss fail");
        }

        [Test]
        public void XSSinject_siganture_test_img_founded()
        {
            string sql = @"<img src=javascript:alert('vulnerable!');>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss fail");
        }

        [Test]
        public void XSSinject_siganture_test_onmousemove_founded()
        {
            string sql = @"<img src=onmouseover=alert('vulnerable!');>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss fail");
        }

        [Test]
        public void XSSinject_siganture_test_img_notFounded()
        {
            string sql = @"<img src=" + '"' + @"path/image.jpeg" + '"' + ">";
            Assert.That(String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss fail");
        }

        [Test]
        public void XSSinject_siganture_test_onerror_notFounded()
        {
            string sql = @"<img src= onerror=alert('vulnerable!');>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss fail");
        }
    }
}
