using FreePayService.Seсurity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace FreePayService.Security
{
    public class UserSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        public UserSecurityTokenServiceConfiguration()
            : base("http://FPSTS")//, new X509SigningCredentials(CertificateFactory.GetCertificate("CN=FPSTS")))
        {
            this.SecurityTokenService = typeof(UserSecurityTokenService);
            this.SecurityTokenHandlers.AddOrReplace(new UserNameTokenHandler());
        }
    }
}