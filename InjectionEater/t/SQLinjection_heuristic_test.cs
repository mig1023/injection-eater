using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_heuristic_test
    {
        [Test]
        public void SQLinject_heuristic_test_founded()
        {
            int sqlTestIndex = 0;

            string[] sqls = new string[] {
                @"' UNION SELECT username, password FROM users--",
                @"1' WHERE user = 't1' OR 1=1--",
                @"1'; SELECT 1,2,3",
                "or 1-- -' or 1 or '1\"or 1 or\"",
                @"1;select 1&id=2 3 from users where id=1--",
            };

            foreach (string sql in sqls)
            {
                sqlTestIndex += 1;
                Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), String.Format("sql #{0} <-- fail", sqlTestIndex));
            }
        }

        public void SQLinject_heuristic_test_notFounded()
        {
            int sqlTestIndex = 0;

            string[] sqls = new string[] {
                @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc",
                "or 1-- -' or 1 or '1\"or 1 or\"",
            };

            foreach (string sql in sqls)
            {
                sqlTestIndex += 1;
                Assert.That(String.IsNullOrEmpty(SQLheuristic.Eat(sql)), String.Format("sql #{0} <-- fail", sqlTestIndex));
            }
        }
    }
}
