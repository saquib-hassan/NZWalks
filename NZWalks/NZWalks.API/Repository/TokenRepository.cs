﻿using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repository
{
    public class TokenRepository : ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            
        }
    }
}
