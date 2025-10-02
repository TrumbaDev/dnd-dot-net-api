using DNDApi.Api.v1.Contracts.User;
using DNDApi.Api.v1.DTO.AuthDTO;
using DNDApi.Api.v1.Models.Entities;
using DNDApi.Api.v1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly JwtService _jwtService;

        public AuthController(
            IConfiguration configuration,
            IUserService userService,
            IPasswordHasher<UserEntity> passwordHasher,
            JwtService jwtService
        )
        {
            _configuration = configuration;
            _userService = userService;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }


        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequest request)
        {
            try
            {
                UserEntity user = await _userService.GetByUserNameAsync(MD5Service.CalculateMD5(request.Username));
                if (user == null)
                {
                    return Unauthorized(new { message = "Неверные учетные данные" });
                }

                PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(
                    user,
                    user.Password,
                    request.Password
                );

                if (result == PasswordVerificationResult.Failed)
                {
                    return Unauthorized(new { message = "Неверные учетные данные" });
                }
                
                string token = _jwtService.GenerateToken(user.Id, user.IsDm);

                return Ok(new AuthResponse
                {
                    Token = token
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error durring authentication",
                    error = ex.Message,
                    details = ex.InnerException?.Message
                });
            }
        }
    }
}