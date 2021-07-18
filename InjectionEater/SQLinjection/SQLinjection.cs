using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class SQLinjection
    {
        public static string Eat(string line)
        {
            if (SQLheuristic.Eat(line))
                return "heuristic panic";

            return SQLsignatures.Eat(line);
        }
    }
}
