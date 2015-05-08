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
        public ServiceRegistrationResult RegisterUser(string name)
        {
            using (PaymentsContext context = new PaymentsContext())
            {
                for (int i = 0; i < context.Users.Count(); i++)
                    if (context.Users.ElementAt(i).Name.Equals(name))
                        return new ServiceRegistrationResult(false, "User with such name already exists.");

                UserInfo userInfo = new UserInfo(name);
                context.Users.Add(userInfo);
                context.SaveChanges();
                return new ServiceRegistrationResult(true, userInfo.ToString());
            }
        }
        public ServiceRegistrationResult MakePayment(string userName, string serviceName)
        {
            using (PaymentsContext context = new PaymentsContext())
            {
                int userId = context.Users.Where(u => u.Name.Equals(userName)).FirstOrDefault().UserInfoId;
                int serviceId = context.WebServices.Where(u => u.Name.Equals(serviceName)).FirstOrDefault().WebServiceInfoId;

                if (userId == 0 || serviceId == 0)
                    return new ServiceRegistrationResult(false, "User or service with such name does not exist.");

                PaymentInfo paymentInfo = new PaymentInfo(userId, serviceId);
                context.Payments.Add(paymentInfo);
                context.SaveChanges();
                return new ServiceRegistrationResult(true, paymentInfo.ToString());
            }
        }
    }
}
