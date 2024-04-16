using Microsoft.AspNetCore.Mvc;
using EstudoBDM.DTOs;
using EstudoBDM.Infraestructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EstudoBDM.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private List<UserDTOs.LoggedUserDTO> _users { get; set; } = new List<UserDTOs.LoggedUserDTO>();
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]

        public IActionResult Login([FromBody] UserDTOs.LoginUserDTO loginUser)
        {
            var user = _jwtService.GenerateJWT(loginUser);

            _users.Add(user);

            return Ok(user);
        }
    }
}
