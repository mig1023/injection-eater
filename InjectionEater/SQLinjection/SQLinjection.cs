using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class SQLinjection
    {
        public static string Eat(string line)
        {
            foreach(SQLsignatures signature in SQLsignatures.list)
                if (RegExp.Test(signature.PrefixrCode + signature.Signature, StringClean.SQLclean(line)))
                    return signature.Name;

            return String.Empty;
        }
    }
}
