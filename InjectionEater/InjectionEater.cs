using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    public class InjectionEater
    {
        public static bool Eat(ref string line, out string detail)
        {
            string needToEatSomething = TryToEat(line);

            if (!String.IsNullOrEmpty(needToEatSomething))
            {
                line = String.Empty;
                detail = needToEatSomething;
                return true;
            }
            else
            {
                detail = String.Empty;
                return false;
            }
        }

        private static string TryToEat(string line)
        {
            string tryEatSQLinjection = SQLinjection.Eat(line);

            if (!String.IsNullOrEmpty(tryEatSQLinjection))
                return String.Format("SQL injection ({0})", tryEatSQLinjection);

            string tryEatXSSinjection = XSSinjection.Eat(line);

            if (!String.IsNullOrEmpty(tryEatXSSinjection))
                return String.Format("XSS injection ({0})", tryEatXSSinjection);

            return String.Empty;
        }
    }
}
