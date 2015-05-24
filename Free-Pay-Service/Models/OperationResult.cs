using System.Runtime.Serialization;

namespace FreePayService.Models
{
    [DataContract] 
    public class OperationResult
    {
        [DataMember]
        public bool IsSuccessful { get; set; }
        [DataMember]
        public string Message { get; set; }
        public OperationResult() { }
        public OperationResult(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}