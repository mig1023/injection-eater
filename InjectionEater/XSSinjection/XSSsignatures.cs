using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionEater
{
    class XSSsignatures
    {
        public string Name = String.Empty;
        public List<string> Signatures;

        private static List<XSSsignatures> AllSignatures = new List<XSSsignatures>
        {
            new XSSsignatures
            {
                Name ="type SCRIPT",
                Signatures = new List<string> {
                    @"<\s*script",
                },
            },
            new XSSsignatures
            {
                Name ="type IMGSCRIPT",
                Signatures = new List<string> {
                    @"<\s*img\s+[^>]*script",
                },
            },
            new XSSsignatures
            {
                Name ="type IMGONMOUSE",
                Signatures = new List<string> {
                    @"<\s*img\s+.*src\s*=.*onmouseover",
                },
            },
        };

        public static string Eat(string line)
        {
            foreach (XSSsignatures currentSignatures in AllSignatures)
                foreach (string signature in currentSignatures.Signatures)
                    if (RegExp.Test(signature, line))
                        return currentSignatures.Name;

            return String.Empty;
        }
    }
}
