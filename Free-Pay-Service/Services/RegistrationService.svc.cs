using FreePayService.Data;
using FreePayService.Models;
using FreePayService.Security;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FreePayService.Services
{
    public class RegistrationService : IRegistrationService
    {
        public ServiceRegistrationResult RegisterService(string name, string uri)
        {
            ServiceRegistrationResult result = new ServiceRegistrationResult();
            using (var context = new PaymentsContext())
            {
                if (context.WebServices.Select(x => x.Name.Equals(name)).Any())
                {
                    result.Message = "Service with this name already exsts";
                    return result;
                }
                WebServiceInfo webService = new WebServiceInfo();
                webService.Name = name;
                webService.Uri = uri;
                context.WebServices.Add(webService);
                context.SaveChanges();
                result.IsSuccessful = true;
            }
            return result;
        }

        public string GetServiceTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
