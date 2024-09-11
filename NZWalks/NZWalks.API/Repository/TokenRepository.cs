using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace NZWalks.API.Repository
{
    public class TokenRepository : ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>();

        }
    }
}
