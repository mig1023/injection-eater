using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class Other_test
    {
        [Test]
        public void Regexp_Test_found()
        {
            Assert.That(RegExp.Test("sometext", "AbCdEfGsometextHiGkLmN"), "regtest#1");
        }

        [Test]
        public void Regexp_Test_notFound()
        {
            Assert.That(!RegExp.Test("someOtherText", "AbCdEfGsomeTextHiGkLmN"), "regtest#1");
        }

        [Test]
        public void Regexp_Delete()
        {
            Assert.AreEqual("AbCdEfGHiGkLmN", RegExp.Delete("AbCdEfGHiGkLmN", "someText"), "regdel#1");
        }

        [Test]
        public void Regexp_Replace()
        {
            Assert.AreEqual("AbCdEfGsomeOtherTextHiGkLmN", RegExp.Replace("AbCdEfGsometextHiGkLmN", "someText", "someOtherText"), "regrpl#1");
        }

        [Test]
        public void StringClean_SQLclean()
        {
            Assert.AreEqual("sometext", StringClean.SQLorXSSclean("some/*long\n \ncomment*/text"), "sqlclean#1");
        }
    }
}
