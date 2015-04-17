using FreePayService.Data;
using FreePayService.Models;
using FreePayService.Security;
using System.Linq;

namespace FreePayService.Services
{
    public class RegistrationService : IRegistrationService
    {
        public ServiceRegistrationResult RegisterService(string name, double price)
        {
            ServiceRegistrationResult result = new ServiceRegistrationResult();
            if (price < 0)
            {
                result.IsSuccessful = false;
                result.Message = "Price is below zero";
            }
            else
            {
                using (var context = new PaymentsContext())
                {
                    if (context.WebServices.Any(w => w.Name.Equals(name)))
                    {
                        result.IsSuccessful = false;
                        result.Message = "A service with this name already exists";
                    }
                    else
                    {
                        WebServiceInfo serviceInfo = new WebServiceInfo(name, price);
                        context.WebServices.Add(serviceInfo);
                        context.SaveChanges();
                        result.IsSuccessful = true;
                        result.ServiceInfo = serviceInfo;
                    }
                }
            }
            return result;
        }
    }
}
