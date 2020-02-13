using DomainSorgula.Component;
using DomainSorgula.Models;

namespace DomainSorgula.Services.Base
{
    public abstract class CheckService
    {
        public static MultiThreadedBindList<Domain> DomainList = new MultiThreadedBindList<Domain>();
        public string ServiceUrl { get; set; }
        public string ValidationText { get; set; }
        public abstract bool CheckIsAvailable(Domain domain);
    }
}
