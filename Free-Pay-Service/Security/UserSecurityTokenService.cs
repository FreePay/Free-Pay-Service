using FreePayService.Security;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Security.Claims;

namespace FreePayService.Seсurity
{
    public class UserSecurityTokenService : SecurityTokenService
    {
        public UserSecurityTokenService(SecurityTokenServiceConfiguration configuration) : base(configuration) { }
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            var requestUri = request.AppliesTo.Uri.AbsoluteUri;
            Scope scope = new Scope(requestUri);
            scope.TokenEncryptionRequired = false;
            scope.SymmetricKeyEncryptionRequired = false;
            return scope;
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, 
            RequestSecurityToken request, 
            Scope scope)
        {
            string userName = principal.Identity.Name;
            var requestUri = request.AppliesTo.Uri.AbsoluteUri;
            bool hadPaid = new UserClaimValidator().HasRightsForAddress(userName, requestUri);
            string authenticationType = principal.Identity.AuthenticationType;
            var outputIdentity = new ClaimsIdentity(authenticationType);
            if (hadPaid)
            {
                outputIdentity.AddClaim(new Claim(ClaimTypes.Name, userName));
            }
            return outputIdentity;
        }
    }
}