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
            Assert.That(!String.IsNullOrEmpty(SQLinjection.Eat(@"' UNION SELECT username, password FROM users--")), "sql#1");
        }

        [Test]
        public void SQLinject_simpletest2()
        {
            Assert.That(String.IsNullOrEmpty(SQLinjection.Eat(@"some text that looks like an injection, because it contains the word UPDATE")), "sql#2");
        }
    }
}
