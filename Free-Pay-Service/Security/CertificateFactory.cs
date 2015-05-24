using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace FreePayService.Security
{
     public static class CertificateFactory
    {
        public static X509Certificate2 GetCertificate(string name)
        {
            var store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            try
            {
                var cert = store.Certificates.OfType<X509Certificate2>()
                    .FirstOrDefault(c => c.SubjectName.Name.Equals(name,
                        StringComparison.OrdinalIgnoreCase));
                return (cert != null) ? new X509Certificate2(cert) : null;
            }
            finally 
            {
                store.Certificates.OfType<X509Certificate2>().ToList().ForEach(c => c.Reset());
                store.Close();
            }
        }
    }
}