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
        ServiceRegistrationResult RegisterService(string name, string uri);
        [OperationContract]
        ServiceRegistrationResult RegisterUser(string name);
        [OperationContract]
        ServiceRegistrationResult MakePayment(string userName, string serviceName);
    }
}
