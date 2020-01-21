using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InjectionEater
{
    class StringClean
    {
        public static string SQLclean(string line)
        {
            return RegExp.Delete(Uri.UnescapeDataString(line), @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/");
        }

        public static string XSSclean(string line)
        {
            return Uri.UnescapeDataString(line);
        }

        public static string SQLkeyRepeatClean(string line)
        {
            foreach (string keyword in new string[] { "select", "union", "update", "insert", "drop", "delete", "alter" })
                line = Regex.Replace(line, keyword, String.Empty, RegexOptions.IgnoreCase);
                
            return line;
        }
    }
}
