﻿using System;
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

        public static List<SQLsignatures> list = new List<SQLsignatures>()
        {
            new SQLsignatures
            {
                Name ="type SELECT",
                Signature = @"(^|\s)select(\s.*\s|\*)from\s",
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
        };
    }
}