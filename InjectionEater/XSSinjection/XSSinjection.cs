using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class XSSinjection
    {
        public static string Eat(string line)
        {
            string signaturePanic = SQLsignatures.Eat(line);

            if (!String.IsNullOrEmpty(signaturePanic))
                return signaturePanic;

            return String.Empty;
        }
    }
}
