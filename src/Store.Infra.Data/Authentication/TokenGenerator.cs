using Microsoft.IdentityModel.Tokens;
using Store.Domain.Authentication;
using Store.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic GenerateToken(UserAuthentication userAuthentication)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", userAuthentication.Email),
                new Claim("Id", userAuthentication.Id.ToString())
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("project"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                acess_token = token,
                expirations = expires
            };
    }
}
