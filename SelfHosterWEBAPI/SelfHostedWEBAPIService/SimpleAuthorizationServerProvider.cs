using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OwinSelfhostSample
{
    internal class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {                      
            // all client are always valdiate
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // validate user

            if ( context.UserName == "admin" && context.Password == "123")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                //identity.AddClaim(new Claim("Email", user.UserEmailID));
                context.Validated(identity);
            }                           
        }
    }
}
