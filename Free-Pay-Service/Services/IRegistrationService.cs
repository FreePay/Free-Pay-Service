using FreePayService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FreePayService.Services
{
    [ServiceContract]
    public interface IRegistrationService
    {
        [OperationContract]
        OperationResult RegisterService(string name, string uri);
        [OperationContract]
        OperationResult RegisterUser(string name);
        [OperationContract]
        OperationResult MakePayment(string userName, string serviceName);
        [OperationContract]
        OperationResult DeleteService(string serviceName);
        [OperationContract]
        List<WebServiceInfo> GetServices();
    }
}
