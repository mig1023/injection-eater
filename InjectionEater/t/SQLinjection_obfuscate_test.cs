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

        [Test]
        public void SQLinject_signature_obfuscate_test2()
        {
            string sql = @"' %55%4eIO%4e%20%53E%4cECT%20username,%20password%20%46%52O%4d%20users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "obfuscate#2");
        }
    }
}
