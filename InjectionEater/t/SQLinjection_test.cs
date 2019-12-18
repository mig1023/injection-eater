﻿using System;
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
        public void SQLinject_signature_obfuscate_test1()
        {
            string sql = @"' UN/**/ION SEL/**/ECT username, password FR/**/OM users--";
            Assert.That(!String.IsNullOrEmpty(SQLsignatures.Eat(sql)), "obfuscate#1");
        }

        [Test]
        public void SQLinject_heuristic_test1()
        {
            string sql = @"' UNION SELECT username, password FROM users--";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic#1");
        }

        [Test]
        public void SQLinject_heuristic_test2()
        {
            string sql = @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc";
            Assert.That(String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic#2");
        }

        [Test]
        public void SQLinject_heuristic_test3()
        {
            string sql = @"1' where user = 't1' OR 1=1--";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic#3");
        }

        [Test]
        public void SQLinject_heuristic_test4()
        {
            string sql = @"1'; select 1,2,3";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic#4");
        }
    }
}
