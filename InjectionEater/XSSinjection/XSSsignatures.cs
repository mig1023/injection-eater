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

        public static string onList = "(onmouseover|onerror|oninput|onfilterchange|onload|onpropertychange|onqt_error)";
        public static string quot = "(\"|')";

        private static List<XSSsignatures> AllSignatures = new List<XSSsignatures>()
        {
            new XSSsignatures
            {
                Name = "type SCRIPT",
                Signatures = new string[] {
                    @"<\s*script",
                    @"href\s*=.*script:",
                    @"value\s*=.*script:",
                    @"alt\s*=.*script:",
                    @"url\s*\(\s*" + quot + @"(java)?script\s*",
                    @"expression\s*\(\s*(java)?script\s*:",
                    @"iframe\s+src\s*=",
                },
            },
            new XSSsignatures
            {
                Name = "type CSS",
                Signatures = new string[] {
                    @"<\s*link.*stylesheet.*href\s*=",
                    @"<\s*style.*import",
                    @"<\s*style.*import",
                    @"content\s*=\s*" + quot + @".*rel\s*=\s*stylesheet",
                    @"-moz-binding\s*:\s*url\s*\(" + quot,
                },
            },
            new XSSsignatures
            {
                Name = "type SRC SCRIPT",
                Signatures = new string[] {
                    @"<\s*(input|img|embed|image|bgsound)\s+.*src\s*=.*script",
                },
            },
            new XSSsignatures
            {
                Name = "type INVOKE",
                Signatures = new string[] {
                    @"=" + quot + @"&{.*\(.*\)}",
                },
            },
            new XSSsignatures
            {
                Name = "type ONSOMETHING",
                Signatures = new string[] {
                    onList + @"\s*=.*script:",
                },
            },
            new XSSsignatures
            {
                Name = "type CLEAN FUNCTION",
                Signatures = new string[] {
                    onList + @"\s*=.*" + quot + @".*\(.*\).*" + quot,
                    onList + @"\s*=.*\(.*\)",
                    onList + @".*=\s*[A-Za-z\-_]+\(.*\)",
                },
            },
            new XSSsignatures
            {
                Name = "type NOTATION HACK",
                Signatures = new string[] {
                    @"background\s*=\s*" + quot + @"\s*(java)?script\s*:",
                    @"-o-link\s*:\s*" + quot + @"(java)?script\s*:",
                    @"<style\s+type\s*=\s*" + quot + @"text/javascript",
                },
            },
        };

        public static string Eat(string line)
        {
            foreach (XSSsignatures currentSignatures in AllSignatures)
                foreach (string signature in currentSignatures.Signatures)
                    foreach (string cleanLine in new string[] { line, StringClean.SQLorXSSclean(line) })
                        if (RegExp.Test(signature, cleanLine))
                            return currentSignatures.Name;

            return String.Empty;
        }
    }
}
