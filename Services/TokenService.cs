using SocialMusic.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SocialMusic.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;


        public TokenService(IConfiguration config)
        {
            _configuration = config;
        }

        public string GenerarToken(CUsuarioMusico user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                );


            var creds =  new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            //Claims
            Claim[] claims = 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            //Crear token
            var token = new JwtSecurityToken(
                    issuer: _configuration["Key:Issuer"],
                    audience: _configuration["Key:Audience:"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Key:Expires"])),
                    signingCredentials: creds

                );

         

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
