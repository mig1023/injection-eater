﻿using System;
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
        public void SQLinject_siganture_test1()
        {
            string sql = @"' UNION SELECT username, password FROM users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql#1");
        }

        [Test]
        public void SQLinject_siganture_test2()
        {
            string text = @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc";
            Assert.That(String.IsNullOrEmpty(SQLsignatures.Eat(text)), "sql#2");
        }

        [Test]
        public void SQLinject_signature_test3()
        {
            string sql = @"1 OR 1=1";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql#3");
        }

        [Test]
        public void SQLinject_signature_test4()
        {
            string sql = @"1 AND 1!=2";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "sql#4");
        }
    }
}
