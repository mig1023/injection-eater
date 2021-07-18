using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class XSSinjection
    {
        public static string Eat(string line) => XSSsignatures.Eat(line);
    }
}
