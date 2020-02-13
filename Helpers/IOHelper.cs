using DomainSorgula.Services;
using DomainSorgula.Component;
using DomainSorgula.Settings;
using DomainSorgula.Models;
using System.IO;
using System.Linq;
using System.Text;
using DomainSorgula.Services.Base;

namespace DomainSorgula.Helpers
{
    class IOHelper
    {
        public static void ReadFromTxt(string path)
        {
            using (var reader = new StreamReader(path, encoding: Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(line) && RegexHelper.IsValidDomain(line))
                        CheckService.DomainList.Add(new Domain() { Index = CheckService.DomainList.Count + 1, Name = line, Status = "Bekleniyor" });
                }
            }
        }
        public static void WriteToDomains(string path)
        {
            using (var writer = new StreamWriter(path, append: true))
            {
                MultiThreadedBindList<Domain> domainList = null;
                switch (Setting.SaveSetting)
                {
                    case SaveSetting.Both:
                        domainList = CheckService.DomainList;
                        break;
                    case SaveSetting.OnlyAvailable:
                        var result = CheckService.DomainList.Where(x => x.Status == "Müsait").ToList();
                        if (result == null)
                            return;
                        domainList = new MultiThreadedBindList<Domain>(result);
                        break;
                    case SaveSetting.OnlyTaken:
                        result = CheckService.DomainList.Where(x => x.Status == "Alınmış").ToList();
                        if (result == null)
                            return;
                        domainList = new MultiThreadedBindList<Domain>(result);
                        break;
                }

                foreach (var domain in domainList)
                {
                    writer.WriteLine($"{domain.Name} => {domain.Status}");
                }

            }
        }
    }
}
