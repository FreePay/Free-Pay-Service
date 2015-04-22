using FreePayService.Data;
using FreePayService.Models;
using FreePayService.Security;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public string GetCertificateNames()
        {
            var store = new X509Store(StoreLocation.LocalMachine);
            string names = "";
            store.Open(OpenFlags.ReadOnly);
            try
            {
                var certificates = store.Certificates.OfType<X509Certificate2>();
                foreach (var c in certificates)
                {
                    names += c.SubjectName.Name + "; ";
                }
            }
            finally
            {
                store.Certificates.OfType<X509Certificate2>().ToList().ForEach(c => c.Reset());
                store.Close();
            }
            return names;
        }
    }
}
