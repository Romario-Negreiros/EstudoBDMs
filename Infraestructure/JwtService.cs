using EstudoBDM.DTOs;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EstudoBDM.Infraestructure
{
    public interface IJwtService
    {
        UserDTOs.LoggedUserDTO GenerateJWT(UserDTOs.LoginUserDTO loginUser);
    }

    public class JwtService : IJwtService
    {
        private IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserDTOs.LoggedUserDTO GenerateJWT(UserDTOs.LoginUserDTO loginUser)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginUser.Name!),
                new Claim("scopes", loginUser.Scopes!.ToString()!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Token expires two hours after generation
            var expiration = DateTime.Now.AddMinutes(120);

            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], claims: claims, expires: expiration, signingCredentials: credentials);

            return new UserDTOs.LoggedUserDTO
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
