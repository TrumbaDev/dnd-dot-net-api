using DNDApi.Api.v1.Contracts.User;
using DNDApi.Api.v1.DTO.AuthDTO;
using DNDApi.Api.v1.Exceptions;
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
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly JwtService _jwtService;

        public AuthController(
            IUserRepository userRepository,
            IPasswordHasher<UserEntity> passwordHasher,
            JwtService jwtService
        )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }


        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] LoginRequest request)
        {
            UserEntity? user = null;
            try
            {
                user = _userRepository.GetUserByName(MD5Service.CalculateMD5(request.Username));
            }
            catch (NotFoundException)
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
    }
}
