using System;
using System.ServiceModel;

namespace FreePayService
{
    [ServiceContract]
    public interface IPaymentService
    {
        [OperationContract]
        String GetMessage();
    }
}
