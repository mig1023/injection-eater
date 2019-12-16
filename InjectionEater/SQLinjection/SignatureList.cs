using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class SignatureList
    {
        public static List<String> signatures = new List<String>()
        {
            @"(^|\s)select(\s.*\s|\*)from\s",
            @"update\s+(low_priority|ignore)?.*\sset\s",
            @"insert\s+(low_priority|delayed|ignore|into)?.*\s(set|values)",
            @"drop\s+(low_priority|quick)?\s*(table|database)\s",
            @"delete\s+(low_priority|quick)?\s*from\s",
            @"alter\s+(ignore\s+)?table\s.*\s(add|drop|change|alter)\s",
        };
    }
}
