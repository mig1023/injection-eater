using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class SQLinjection
    {
        public static bool Eat(ref string line)
        {
            foreach(string signature in SignatureList.signatures)
                if (RegExp.Test(signature, line))
                {
                    line = String.Empty;
                    return true;
                }

            return false;
        }
    }
}
