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
        public void SimpleSQLinject_test()
        {
            string simpleInject = @"' UNION SELECT username, password FROM users--";
            bool test = SQLinjection.Eat(ref simpleInject);
            Assert.AreEqual(test, true);
        }
    }
}
