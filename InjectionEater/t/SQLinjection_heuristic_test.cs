using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class SQLinjection_heuristic_test
    {
        [Test]
        public void SQLinject_heuristic_test_union_founded() =>
            Assert.IsTrue(SQLheuristic.Eat(@"' UNION SELECT username, password FROM users--"));

        [Test]
        public void SQLinject_heuristic_test_equal_founded() =>
            Assert.IsTrue(SQLheuristic.Eat(@"1' WHERE user = 't1' OR 1=1--"));

        [Test]
        public void SQLinject_heuristic_test_second_request_founded() =>
            Assert.IsTrue(SQLheuristic.Eat(@"'; SELECT * FROM information_schema.tables"));

        [Test]
        public void SQLinject_heuristic_test_uniontext_notFounded() =>
            Assert.IsFalse(SQLheuristic.Eat("some text that looks like an injection, " +
                "because it contains the words UNION, SELECT and FROM etc"));

        [Test]
        public void SQLinject_heuristic_test_ortext_notFounded() =>
            Assert.IsFalse(SQLheuristic.Eat(@"or 1 or 2 or 3 or 4 -- 2 1"));
    }
}
