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
        public List<string> Signatures;
        public string PrefixrCode = @"(?:\|\||union|and|or)\s+";

        private static List<SQLsignatures> AllSignatures = new List<SQLsignatures>()
        {
            new SQLsignatures
            {
                Name ="type SELECT",
                Signatures = new List<string> {
                    @"select(\s.*\s|\s?\*\s?)from\s",
                },
            },
            new SQLsignatures
            {
                Name ="type UPDATE",
                Signatures = new List<string> {
                    @"update\s+(low_priority|ignore)?.*\sset\s",
                },
            },
            new SQLsignatures
            {
                Name ="type INSERT",
                Signatures = new List<string> {
                    @"insert\s+(low_priority|delayed|ignore|into)?.*\s(set|values)",
                },
            },
            new SQLsignatures
            {
                Name ="type DROP",
                Signatures = new List<string> {
                    @"drop\s+(low_priority|quick)?\s*(table|database)\s",
                },
            },
            new SQLsignatures
            {
                Name ="type DELETE",
                Signatures = new List<string> {
                    @"delete\s+(low_priority|quick)?\s*from\s",
                },
            },
            new SQLsignatures
            {
                Name ="type ALTER",
                Signatures = new List<string> {
                    @"alter\s+(ignore\s+)?table\s.*\s(add|drop|change|alter)\s",
                },
            },
            new SQLsignatures
            {
                Name ="type EQUALITY",
                Signatures = new List<string> {
                    @"(.+)\s*=\s*\1",
                    @"(.+)\s*!=\s*(.+)",
                },
            },
        };

        public static string Eat(string line)
        {
            foreach (SQLsignatures currentSignatures in AllSignatures)
                foreach (string signature in currentSignatures.Signatures)
                    foreach (string cleanLine in new string[] { line, StringClean.SQLclean(line), StringClean.SQLkeyRepeatClean(line) })
                        if (RegExp.Test(currentSignatures.PrefixrCode + signature, cleanLine))
                            return currentSignatures.Name;

            return String.Empty;
        }
    }
}
