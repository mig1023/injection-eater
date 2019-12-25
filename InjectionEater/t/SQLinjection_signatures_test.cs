using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_signatures_test
    {
        [Test]
        public void SQLinject_siganture_test_founded()
        {
            int sqlTestIndex = 0;

            string[] sqls = new string[] {
                @"' UNION SELECT username, password FROM users--",
                @"1 OR 1=1",
                @"1 AND 1!=2",
                @"1 OR 0x50=0x50",
            };

            foreach (string sql in sqls)
            {
                sqlTestIndex += 1;
                Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), String.Format("sql #{0} <-- fail", sqlTestIndex));
            }
        }

        [Test]
        public void SQLinject_siganture_test_notFounded()
        {
            int sqlTestIndex = 0;

            string[] sqls = new string[] {
                @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc",
            };

            foreach (string sql in sqls)
            {
                sqlTestIndex += 1;
                Assert.That(String.IsNullOrEmpty(SQLsignatures.Eat(sql)), String.Format("sql #{0} <-- fail", sqlTestIndex));
            }
        }
    }
}
