using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _03.JsonWebToken.Models.Auth
{
    public class AcademyTokenHandler
    {
        public Token CreateAccessToken()
        {
            var claimsdata = new[]
            {
                new Claim(ClaimTypes.Email, ""),
            };
            Token token = new Token();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ironmaidenpentagramslipknotironmaidenpentagramslipknot"));

            //Token şifreleme algoritması
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpireDate = DateTime.Now.AddMinutes(30);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "berre@mail.com",
                audience: "berre1@mail.com",
                expires: token.ExpireDate,
                signingCredentials: signingCredentials,
                claims: claimsdata
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
