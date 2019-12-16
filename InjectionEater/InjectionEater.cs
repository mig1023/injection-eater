using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    public class InjectionEater
    {
        public static bool Eat(ref string line)
        {
            bool result = false;

            result |= SQLinjection.Eat(ref line);

            return result;
        }
    }
}
