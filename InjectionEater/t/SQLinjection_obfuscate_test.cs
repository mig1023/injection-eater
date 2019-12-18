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
        public void SQLinject_signature_obfuscate_test1()
        {
            string sql = @"' UN/**/ION SEL/**/ECT username, password FR/**/OM users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "obfuscate#1");
        }

        // https://www.owasp.org/index.php/SQL_Injection_Bypassing_WAF
    }
}
