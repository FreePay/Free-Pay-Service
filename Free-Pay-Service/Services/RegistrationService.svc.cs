using FreePayService.Data;
using FreePayService.Models;
using FreePayService.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FreePayService.Services
{
    public class RegistrationService : IRegistrationService
    {
        public OperationResult RegisterService(string name, string uri)
        {
            OperationResult result = new OperationResult();
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
        public OperationResult RegisterUser(string name)
        {
            using (PaymentsContext context = new PaymentsContext())
            {
                if (context.Users.Any(u => u.Name.Equals(name)))
                {
                    return new OperationResult(false, "User with such name already exists.");
                }
                UserInfo userInfo = new UserInfo(name);
                context.Users.Add(userInfo);
                context.SaveChanges();
                return new OperationResult(true, userInfo.ToString());
            }
        }
        public OperationResult MakePayment(string userName, string serviceName)
        {
            using (PaymentsContext context = new PaymentsContext())
            {
                UserInfo user = context.Users.Where(u => u.Name.Equals(userName)).FirstOrDefault();
                WebServiceInfo service = context.WebServices.Where(u => u.Name.Equals(serviceName)).FirstOrDefault();

                if (user == null || service == null)
                    return new OperationResult(false, "User or service with such name does not exist.");

                if(context.Payments.Any(p => p.ServiceId == service.WebServiceInfoId && p.UserId == user.UserInfoId))
                    return new OperationResult(false, "Already paid");

                PaymentInfo paymentInfo = new PaymentInfo(user.UserInfoId, service.WebServiceInfoId);
                context.Payments.Add(paymentInfo);
                context.SaveChanges();
                return new OperationResult(true, paymentInfo.ToString());
            }
        }
        public OperationResult DeleteService(string serviceName)
        {
            OperationResult result = new OperationResult();
            using (PaymentsContext context = new PaymentsContext())
            {
                List<WebServiceInfo> foundServices = context.WebServices.Where(x => x.Name.Equals(serviceName)).ToList();
                if (foundServices.Any())
                {
                    context.WebServices.RemoveRange(context.WebServices.Where(w => w.Name.Equals(serviceName)));
                    context.SaveChanges();
                    result.IsSuccessful = true;
                }
                else
                {
                    result.Message = "Service not found";
                }
            }
            return result;
        }
        public List<WebServiceInfo> GetServices()
        {
            using (PaymentsContext context = new PaymentsContext())
            {
                return context.WebServices.ToList();
            }
        }
    }
}
