using Lazy.SecurityLayers.SecureAuth.Config;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lazy.SecurityLayers.SecureAuth.Services
{
    public class TokenManager
    {
        private readonly JwtSecurityTokenHandler _handler;
        private List<Claim> _claims;

        public TokenManager(JwtSecurityTokenHandler handler)
        {
            _handler = handler;
            _claims = new List<Claim>();
        }

        public TokenManager AddClaimSid(string sid)
        {
            _claims.Add(new Claim(ClaimTypes.Sid, sid));
            return this;
        }
        public TokenManager AddClaimRole(string role)
        {
            _claims.Add(new Claim(ClaimTypes.Role, role));
            return this;
        }

        public string GetClaimFromToken(string header, string claimType)
        {
            if (string.IsNullOrEmpty(claimType) || !header.StartsWith("Bearer "))
                throw new ArgumentException("Missing or invalid token");

            string jwtToken = header.Substring("Bearer ".Length);
            var jsonToken = _handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken == null)
                throw new ArgumentException("Inavlid token");

            string claimValue = jsonToken.Claims.First(claim => claim.Type == claimType).Value;

            if (string.IsNullOrEmpty(claimValue))
                throw new ArgumentException("Inavlid token");

            return claimValue;
        }

        public string GenerateToken(TokenParameters parameters)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(parameters.SecretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: _claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(1),
                issuer: parameters.Issuer,
                audience: parameters.Audience
                );

            return _handler.WriteToken(token);
        }
    }
}
