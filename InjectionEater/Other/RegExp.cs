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
        public static bool Test(string exp, string line) =>
            new Regex(exp, RegexOptions.IgnoreCase).Match(line).Success;

        public static string Replace(string line, string from, string to) =>
            Regex.Replace(line, from, to, RegexOptions.IgnoreCase);

        public static string Delete(string from, string what) =>
            Regex.Replace(from, what, String.Empty, RegexOptions.IgnoreCase);
    }
}
