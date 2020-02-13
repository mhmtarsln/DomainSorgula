using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DomainSorgula.Helpers
{
    public static class RequestHelper
    {
        static RequestHelper()
        {
            ServicePointManager.DefaultConnectionLimit = 10000;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public static string Get(string url)
        {
            string result = "";
            try
            {
                Encoding encoding;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Proxy = new WebProxy();
                using (var response = request.GetResponse())
                {
                    try
                    {
                        encoding = Encoding.GetEncoding((response as HttpWebResponse).CharacterSet);
                    }
                    catch (ArgumentException)
                    {
                        encoding = Encoding.UTF8;
                    }
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, encoding))
                            result = reader.ReadToEnd();
                    }
                }
                request.Abort();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Siteye ({url}) ulaşılmaya çalışılırken hata oldu!", ex);
            } 
            return result;

        } 
    }
}