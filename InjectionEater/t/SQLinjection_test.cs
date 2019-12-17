using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_test
    {
        [Test]
        public void SQLinject_simpletest1()
        {
            string sql = @"' UNION SELECT username, password FROM users--";
            Assert.That(!String.IsNullOrEmpty(SQLinjection.Eat(sql)), "sql#1");
        }

        [Test]
        public void SQLinject_simpletest2()
        {
            string text = @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc";
            Assert.That(String.IsNullOrEmpty(SQLinjection.Eat(text)), "sql#2");
        }

        [Test]
        public void SQLinject_obfuscatetest1()
        {
            string sql = @"' UN/**/ION SEL/**/ECT username, password FR/**/OM users--";
            Assert.That(!String.IsNullOrEmpty(SQLinjection.Eat(sql)), "obfuscate#1");
        }
    }
}
