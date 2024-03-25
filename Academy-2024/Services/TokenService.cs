using Academy_2024.Dtos;
using Academy_2024.Models;
using Academy_2024.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace Academy_2024.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public TokenDto CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.Add(new TimeSpan(0, 30, 0));

            var tokenDescriptor = new JwtSecurityToken
            (
                _jwtOptions.Issuer,
                _jwtOptions.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor),
                Expires = expires
            };
        }

        //DEBUG!
        /*
        public string GetUserIdFromToken(HttpHeaders headers, string secret)
        {
            String token = headers.GetValues("Authorization").First();
            String jwt = token.Replace("Bearer", "");
            Console.WriteLine("DEBUG! => JWT: " + jwt);
            

            return "";
        }
        */
    }
}
