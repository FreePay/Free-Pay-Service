using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace FreePayService.Security
{
    public class UserNameTokenHandler : UserNameSecurityTokenHandler
    {
        public override bool CanValidateToken { get { return true; } }

        public override ReadOnlyCollection<ClaimsIdentity> ValidateToken(SecurityToken token)
        {
            UserNameSecurityToken userNameToken = token as UserNameSecurityToken;
            Claim nameClame = new Claim(System.IdentityModel.Claims.ClaimTypes.Name, userNameToken.UserName);
            var identity = new ClaimsIdentity(new Claim[] { nameClame }, "NameToken");
            return new ReadOnlyCollection<ClaimsIdentity>(new ClaimsIdentity[] { identity });
        }
    }
}