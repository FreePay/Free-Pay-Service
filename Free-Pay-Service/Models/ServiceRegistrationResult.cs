using System.Runtime.Serialization;

namespace FreePayService.Models
{
    [DataContract] 
    public class ServiceRegistrationResult
    {
        [DataMember]
        public bool IsSuccessful { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public WebServiceInfo ServiceInfo { get; set; }
    }
}