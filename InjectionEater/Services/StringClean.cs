using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class StringClean
    {
        public static string SQLclean(string line)
        {
            return RegExp.Delete(line, @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/");
        }
    }
}
