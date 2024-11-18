﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiteApi.Application.Interfaces.Tokens;
using SiteApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokensSettings.Secret)),
                ValidateActor = false
            };

            JwtSecurityTokenHandler tokenHandler = new();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("token bulunamadı.");

            return principal;
        }
    }
}
