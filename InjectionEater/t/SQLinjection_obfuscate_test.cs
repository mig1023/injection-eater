using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_obfuscate_test
    {
        [Test]
        public void SQLinject_obfuscate_test_comments_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"' UN/**/ION SEL/**/ECT username, password FR/**/OM users--"));

        [Test]
        public void SQLinject_obfuscate_test_url_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat("' %55%4eIO%4e%20%53E%4cECT%20username,%20password%20%46%52O%4d%20users--"));

        [Test]
        public void SQLinject_obfuscate_test_case_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"' UNiOn SelECt username, password fROm users--"));

        [Test]
        public void SQLinject_obfuscate_test_duplicates_founded() =>
            Assert.IsNotEmpty(SQLsignatures.Eat(@"' UNIunionON SEselectLECT username, password FROM users--"));
    }
}
