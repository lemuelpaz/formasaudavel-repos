using API.Model.Data;
using API.Source.Base.Utils;
using API.Source.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Source.Base.Middlewares
{
    public static class TokenService
    {

        /// <summary>
        /// Gera o auth Token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static AuthResponse GenerateToken(Profissional request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.JwtKey!);
            var expiresIn = DateTime.UtcNow.AddHours(5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

                    new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sid, request.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                        new Claim(ClaimTypes.Email, request.Email!),
                        new Claim(ClaimTypes.Name, request.Nome!),
                    }
                ),
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AuthResponse response = new AuthResponse()
            {
                access_token = tokenHandler.WriteToken(token),
                expires_in = expiresIn.Millisecond,
                token_type = "Bearer"
            };
            
            return response;
        }
    }
}
