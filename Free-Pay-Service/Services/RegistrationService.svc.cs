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
                if (context.WebServices.Any(x => x.Name.Equals(name)))
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
                if (context.Users.Any(u => u.Name.Equals(name)))
                {
                    return new ServiceRegistrationResult(false, "User with such name already exists.");
                }
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
                UserInfo user = context.Users.Where(u => u.Name.Equals(userName)).FirstOrDefault();
                WebServiceInfo service = context.WebServices.Where(u => u.Name.Equals(serviceName)).FirstOrDefault();

                if (user == null || service == null)
                    return new ServiceRegistrationResult(false, "User or service with such name does not exist.");

                if(context.Payments.Any(p => p.ServiceId == service.WebServiceInfoId && p.UserId == user.UserInfoId))
                    return new ServiceRegistrationResult(false, "Already paid");

                PaymentInfo paymentInfo = new PaymentInfo(user.UserInfoId, service.WebServiceInfoId);
                context.Payments.Add(paymentInfo);
                context.SaveChanges();
                return new ServiceRegistrationResult(true, paymentInfo.ToString());
            }
        }
    }
}
