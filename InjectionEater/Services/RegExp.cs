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
            return new Regex(exp, RegexOptions.IgnoreCase).Match(line).Success;
        }
    }
}
