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
        public string[] Signatures;

        private static List<XSSsignatures> AllSignatures = new List<XSSsignatures>()
        {
            new XSSsignatures
            {
                Name ="type SCRIPT",
                Signatures = new string[] {
                    @"<\s*script",
                },
            },
            new XSSsignatures
            {
                Name ="type IMGSRC",
                Signatures = new string[] {
                    @"<\s*img\s+.*src\s*=.*script",
                },
            },
            new XSSsignatures
            {
                Name ="type IMGONMOUSE",
                Signatures = new string[] {
                    @"<\s*img\s+.*src\s*=.*onmouseover",
                },
            },
        };

        public static string Eat(string line)
        {
            foreach (XSSsignatures currentSignatures in AllSignatures)
                foreach (string signature in currentSignatures.Signatures)
                    foreach (string cleanLine in new string[] { line })
                        if (RegExp.Test(signature, cleanLine))
                            return currentSignatures.Name;

            return String.Empty;
        }
    }
}
