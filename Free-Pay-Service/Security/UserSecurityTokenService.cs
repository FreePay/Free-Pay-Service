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

            Claim nameClame = new Claim(System.IdentityModel.Claims.ClaimTypes.Name, userName);
            outputIdentity.AddClaim(nameClame);
            return outputIdentity;
        }
    }
}