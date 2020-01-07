using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_obfuscate_test
    {
        [Test]
        public void SQLinject_obfuscate_test_comments_founded()
        {
            string sql = @"' UN/**/ION SEL/**/ECT username, password FR/**/OM users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_obfuscate_test_url_founded()
        {
            string sql = @"' %55%4eIO%4e%20%53E%4cECT%20username,%20password%20%46%52O%4d%20users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_obfuscate_test_case_founded()
        {
            string sql = @"' UNiOn SelECt username, password fROm users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }

        [Test]
        public void SQLinject_obfuscate_test_duplicates_founded()
        {
            string sql = @"' UNIunionON SEselectLECT username, password FROM users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql fail");
        }
    }
}
