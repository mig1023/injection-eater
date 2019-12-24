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
        public string Signature = String.Empty;
        public string PrefixrCode = @"(\|\||union|and)\s+";

        private static List<SQLsignatures> Signatures = new List<SQLsignatures>()
        {
            new SQLsignatures
            {
                Name ="type SELECT",
                Signature = @"select(\s.*\s|\s?\*\s?)from\s",
            },
            new SQLsignatures
            {
                Name ="type UPDATE",
                Signature = @"update\s+(low_priority|ignore)?.*\sset\s",
            },
            new SQLsignatures
            {
                Name ="type INSERT",
                Signature = @"insert\s+(low_priority|delayed|ignore|into)?.*\s(set|values)",
            },
            new SQLsignatures
            {
                Name ="type DROP",
                Signature = @"drop\s+(low_priority|quick)?\s*(table|database)\s",
            },
            new SQLsignatures
            {
                Name ="type DELETE",
                Signature = @"delete\s+(low_priority|quick)?\s*from\s",
            },
            new SQLsignatures
            {
                Name ="type ALTER",
                Signature = @"alter\s+(ignore\s+)?table\s.*\s(add|drop|change|alter)\s",
            },
            new SQLsignatures
            {
                Name ="type EQUALITY",
                Signature = @"\s(.+)\s*=\s*$1",
            },
        };

        public static string Eat(string line)
        {
            foreach (SQLsignatures signature in Signatures)
                foreach (string cleanLine in new string[] { StringClean.SQLclean(line), StringClean.SQLkeyRepeatClean(line) })
                    if (RegExp.Test(signature.PrefixrCode + signature.Signature, cleanLine))
                        return signature.Name;

            return String.Empty;
        }
    }
}
