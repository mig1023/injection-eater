using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_heuristic_test
    {
        [Test]
        public void SQLinject_heuristic_test_union_founded()
        {
            string sql = @"' UNION SELECT username, password FROM users--";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic fail");
        }

        [Test]
        public void SQLinject_heuristic_test_equal_founded()
        {
            string sql = @"1' WHERE user = 't1' OR 1=1--";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic fail");
        }

        [Test]
        public void SQLinject_heuristic_test_select123_founded()
        {
            string sql = @"1'; SELECT 1,2,3";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic fail");
        }

        [Test]
        public void SQLinject_heuristic_test_or_founded()
        {
            string sql = "or 1-- -' or 1 or '1\"or 1 or\"";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic fail");
        }

        [Test]
        public void SQLinject_heuristic_test_ampersand_founded()
        {
            string sql = @"1;select 1&id=2 3 from users where id=1--";
            Assert.That(!String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "heuristic fail");
        }

        [Test]
        public void SQLinject_heuristic_test_uniontext_notFounded()
        {
            string sql = @"some text that looks like an injection, because it contains the words UNION, SELECT and FROM etc";
            Assert.That(String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "not sql heuristic fail");
        }

        [Test]
        public void SQLinject_heuristic_test_ortext_notFounded()
        {
            string sql = @"or 1 or 2 or 3 or 4 -- 2 1";
            Assert.That(String.IsNullOrEmpty(SQLheuristic.Eat(sql)), "not sql heuristic fail");
        }
    }
}
