using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tai.Authentications.Entities;
using Tai.Authentications.Interfaces;

namespace Tai.Authentications.Services
{
    public class TokenService : ITokenService
    {
        private IDateTime _dateTime;
        public TimeSpan ExpiryDuration = new TimeSpan(1, 0, 0);

        public TokenService(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public string BuildToken(string key, string issuer, User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserNameSurname.Name),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer,
                issuer,
                claims,
                expires: _dateTime.Now.Add(ExpiryDuration),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
