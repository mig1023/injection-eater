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
        public void Regexp_Test_SimpleText_found() =>
            Assert.IsTrue(RegExp.Test("sometext", "AbCdEfGsOmeTeXtHiGkLmN"));

        [Test]
        public void Regexp_Test_WithSpaces_found() =>
            Assert.IsTrue(RegExp.Test(@"some\s+text", "AbCdEfGsOme   TeXtHiGkLmN"));

        [Test]
        public void Regexp_Test_WithClasses_found() =>
            Assert.IsTrue(RegExp.Test(@"some[TEte]+xt", "AbCdEfGsOmeTeXtHiGkLmN"));

        [Test]
        public void Regexp_Test_notFound() =>
            Assert.IsFalse(RegExp.Test("someOtherText", "AbCdEfGsOmeTeXtHiGkLmN"));

        [Test]
        public void Regexp_Delete() =>
            Assert.AreEqual("AbCdEfGHiGkLmN", RegExp.Delete("AbCdEfGHiGkLmN", "someText"));

        [Test]
        public void Regexp_Replace() =>
            Assert.AreEqual("AbCdEfGsomeOtherTextHiGkLmN",
            RegExp.Replace("AbCdEfGsometextHiGkLmN", "someText", "someOtherText"));

        [Test]
        public void StringClean_SQLclean() =>
            Assert.AreEqual("sometext", StringClean.SQLclean("some/*long\n \ncomment*/text"));
    }
}
