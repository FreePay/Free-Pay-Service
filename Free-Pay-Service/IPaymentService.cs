using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Free_Pay_Service
{
    [ServiceContract]
    public interface IPaymentService
    {
        [OperationContract]
        String GetMessage();
    }
}
