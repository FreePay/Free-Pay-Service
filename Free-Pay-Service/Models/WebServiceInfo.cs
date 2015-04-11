using System.Runtime.Serialization;

namespace FreePayService.Models
{
    [DataContract] 
    public class WebServiceInfo
    {
        public int WebServiceInfoId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
        public WebServiceInfo(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}