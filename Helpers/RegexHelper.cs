using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomainSorgula.Helpers
{
    class RegexHelper
    {
        public static bool IsValidDomain(string domain)
        {
            return Regex.IsMatch(domain, @"^(?:\w*\.|)(?:\w*)\.(?:[a-zA-Z]*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        public static string GetDomainExtension(string domain)
        {
            return Regex.Match(domain, @".*?\.(?<Extension>.*)", RegexOptions.Compiled).Groups["Extension"].Value;
        }
    }
}
