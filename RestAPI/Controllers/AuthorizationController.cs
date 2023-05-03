using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Domain.Users;
using RestAPI.Infrastructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UsersRepository _usersRepository;
        public AuthorizationController(IConfiguration config, UsersRepository usersRepository)
        {
            _config = config;
            _usersRepository = usersRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            User user = await _usersRepository.GetById(id);
            if (user is null) return NotFound();
            return Ok(new UserDto()
            {
                UserName = user.UserName,
            });
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserCreateDto userDto)
        {
            // TODO: Compare encrypted passwords.
            ActionResult responseActionResult;
            try
            {
                User user = await _usersRepository.GetByUserName(userDto.UserName);
                if (user is null || (userDto.Password != user.Password))
                {
                    responseActionResult = Unauthorized();
                }
                else
                {
                    responseActionResult = Ok(new { token = GenerateToken(user.UserName) });
                }
            }
            catch (Exception ex)
            {
                responseActionResult = StatusCode(500, "An error occurred while processing your request.");
            }

            return responseActionResult;
        }

        [HttpPost("/register")]
        public async Task<ActionResult<UserDto>> Register(UserCreateDto userCreateDto)
        {
            // TODO: Encrypt passwords.
            User user = new User(userCreateDto);
            await _usersRepository.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, new UserDto() { UserName = user.UserName });
        }

        private string GenerateToken(string userName)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("SecretKey").Value));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: signingCredentials);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    };
}
