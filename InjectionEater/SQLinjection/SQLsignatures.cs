using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class SQLsignatures
    {
        public string Name = String.Empty;
        public string[] Signatures;
        public string PrefixrCode = @"(?:\|\||union|and|or)\s+";

        private static List<SQLsignatures> AllSignatures = new List<SQLsignatures>()
        {
            new SQLsignatures
            {
                Name ="type SELECT",
                Signatures = new string[] {
                    @"select(\s.*\s|\s?\*\s?)from\s",
                },
            },
            new SQLsignatures
            {
                Name ="type UPDATE",
                Signatures = new string[] {
                    @"update\s+(low_priority|ignore)?.*\sset\s",
                },
            },
            new SQLsignatures
            {
                Name ="type INSERT",
                Signatures = new string[] {
                    @"insert\s+(low_priority|delayed|ignore|into)?.*\s(set|values)",
                },
            },
            new SQLsignatures
            {
                Name ="type DROP",
                Signatures = new string[] {
                    @"drop\s+(low_priority|quick)?\s*(table|database)\s",
                },
            },
            new SQLsignatures
            {
                Name ="type DELETE",
                Signatures = new string[] {
                    @"delete\s+(low_priority|quick)?\s*from\s",
                },
            },
            new SQLsignatures
            {
                Name ="type ALTER",
                Signatures = new string[] {
                    @"alter\s+(ignore\s+)?table\s.*\s(add|drop|change|alter)\s",
                },
            },
            new SQLsignatures
            {
                Name ="type EQUALITY",
                Signatures = new string[] {
                    @"(.+)\s*=\s*\1",
                    @"(.+)\s*!=\s*(.+)",
                },
            },
        };

        public static string Eat(string line)
        {
            foreach (SQLsignatures currentSignatures in AllSignatures)
                foreach (string signature in currentSignatures.Signatures)
                    foreach (string cleanLine in new string[] { line, StringClean.SQLorXSSclean(line), StringClean.SQLkeyRepeatClean(line) })
                        if (RegExp.Test(currentSignatures.PrefixrCode + signature, cleanLine))
                            return currentSignatures.Name;

            return String.Empty;
        }
    }
}
