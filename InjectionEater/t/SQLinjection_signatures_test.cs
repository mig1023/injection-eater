using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_signatures_test
    {
        [Test]
        public void SQLinject_siganture_test_union_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"' UNION SELECT username, password FROM users--"));

        [Test]
        public void SQLinject_siganture_test_equal_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"1 OR 1=1"));

        [Test]
        public void SQLinject_siganture_test_notequal_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"1 AND 1!=2"));

        [Test]
        public void SQLinject_siganture_test_something_equal_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"1 OR 0x50=0x50"));

        [Test]
        public void SQLinject_siganture_test_uniontext_notFounded() =>
            Assert.IsEmpty(SQLsignatures.Eat("some text that looks like an injection, " +
                "because it contains the words UNION, SELECT and FROM etc"));
    }
}
