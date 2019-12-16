using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InjectionEater
{
    class RegExp
    {
        public static bool Test(string exp, string line)
        {
            Regex regexTest = new Regex(exp, RegexOptions.IgnoreCase);

            Match condition = regexTest.Match(line);

            return condition.Success;
        }
    }
}
