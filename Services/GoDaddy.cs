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
    class GoDaddy : CheckService
    {
        public GoDaddy()
        {
            base.ServiceUrl = "https://www.godaddy.com/domainfind/v1/search/exact?q=";
            base.ValidationText = "AvailabilityLabel\":\"available_for_registration";
        }
        public override bool CheckIsAvailable(Domain domain)
        {
            var response = RequestHelper.Get($"{base.ServiceUrl}{domain.Name}");
            if (response.Contains(base.ValidationText))
                return true;
            else
                return false;            
        }
    }
}
