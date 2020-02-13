using DomainSorgula.Helpers;
using DomainSorgula.Models;
using DomainSorgula.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSorgula.Services
{
    class BlueHost : CheckService
    {
        public BlueHost()
        {
            base.ServiceUrl = "https://registration.bluehost.com/domains/search/{0}?suggestions=0&aftermarket=false&propertyID=52&searchTerm={1}&tlds={2}&currency=USD";
            base.ValidationText = "availability\":true";
        }
        public override bool CheckIsAvailable(Domain domain)
        {
            var response = RequestHelper.Get(string.Format(base.ServiceUrl, domain.Name, domain.Name, domain.Extension));
            if (response.Contains(base.ValidationText))
                return true;
            else
                return false;
        }
    }
}
