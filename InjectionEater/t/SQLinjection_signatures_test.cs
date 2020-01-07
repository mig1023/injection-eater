using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_signatures_test
    {
        [Test]
        public void SQLinject_siganture_test_union_founded()
        {
            string sql = @"' UNION SELECT username, password FROM users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_siganture_test_equal_founded()
        {
            string sql = @"1 OR 1=1";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_siganture_test_notequal_founded()
        {
            string sql = @"1 AND 1!=2";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_siganture_test_something_equal_founded()
        {
            string sql = @"1 OR 0x50=0x50";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_siganture_test_uniontext_notFounded()
        {
            string sql = @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc";
            Assert.That(String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "not sql fail");
        }
    }
}
