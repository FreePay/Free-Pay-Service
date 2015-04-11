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
        ServiceRegistrationResult RegisterService(string name, double price);
    }
}
