using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiteApi.Application.Interfaces.Tokens;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiteApi.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
       
        private readonly TokenSettings tokensSettings;
        private readonly UserManager<User> userManager;

        public TokenService(IOptions<TokenSettings> options,UserManager<User> userManager)
        {
            tokensSettings = options.Value;
            this.userManager = userManager;
        }

     
        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jwt id
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),            //user id
                new Claim(JwtRegisteredClaimNames.Email, user.Email),               // email    
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokensSettings.Secret));

            var token = new JwtSecurityToken(
                  issuer: tokensSettings.Issuer,
                  audience: tokensSettings.Auidience,
                  expires: DateTime.Now.AddMinutes(tokensSettings.TokenValidityInMunitiues),
                  claims: claims,
                  signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user, claims);

            return token;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken()
        {
            throw new NotImplementedException();
        }
    }
}
