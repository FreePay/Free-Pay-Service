using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreePayService.Models
{
    public class WebServiceInfo
    {
        public int WebServiceInfoId { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public WebServiceInfo() { }
        public WebServiceInfo(string name, string uri)
        {
            Name = name;
            Uri = uri;
        }
    }
}