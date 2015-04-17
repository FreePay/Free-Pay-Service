using FreePayService.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace FreePayService.Seсurity
{
    public class UserSecurityTokenService : SecurityTokenService
    {
        public UserSecurityTokenService(SecurityTokenServiceConfiguration configuration) : base(configuration) { }
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            var requestUri = request.AppliesTo.Uri.AbsoluteUri;
            var signingCredentials = new X509EncryptingCredentials(CertificateFactory.GetCertificate("CN=RP"));
            Scope scope = new Scope(requestUri, SecurityTokenServiceConfiguration.SigningCredentials, signingCredentials);
            return scope;
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, 
            RequestSecurityToken request, 
            Scope scope)
        {
            string userName = principal.Identity.Name;
            var requestUri = request.AppliesTo.Uri.AbsoluteUri;
            string authenticationType = principal.Identity.AuthenticationType;

            var outputIdentity = new ClaimsIdentity(authenticationType);

            Claim nameClame = new Claim(System.IdentityModel.Claims.ClaimTypes.Name, userName);
            outputIdentity.AddClaim(nameClame);
            return outputIdentity;
        }
    }
}