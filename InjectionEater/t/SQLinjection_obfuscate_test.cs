using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_obfuscate_test
    {
        [Test]
        public void SQLinject_obfuscate_test_founded()
        {
            int sqlTestIndex = 0;

            string[] sqls = new string[] {
                @"' UN/**/ION SEL/**/ECT username, password FR/**/OM users--",
                @"' %55%4eIO%4e%20%53E%4cECT%20username,%20password%20%46%52O%4d%20users--",
                @"' UNiOn SelECt username, password fROm users--",
                @"' UNIunionON SEselectLECT username, password FROM users--"
            };

            foreach (string sql in sqls)
            {
                sqlTestIndex += 1;
                Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), String.Format("sql #{0} <-- fail", sqlTestIndex));
            }
        }
    }
}
