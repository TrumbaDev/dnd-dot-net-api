using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace DNDApi.Api.v1.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(int userId, bool isDm)
        {
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            [
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role, isDm ? "DM" : "Player"),
                new Claim("isDm", isDm.ToString())
            ];

            JwtSecurityToken token = new(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"] ?? "24")),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetUserIdFromPrincipal(ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new SecurityTokenException("Claim с ID пользователя не найден в токене");
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new SecurityTokenException("ID пользователя в токене не является числом");
            }

            return userId;
        }
        
        public static bool GetUserIsDmFromPrincipal(ClaimsPrincipal user)
        {
            var isDmClaim = user.FindFirst("isDm");

            if (isDmClaim == null)
            {
                throw new SecurityTokenException("Claim с IsDM пользователя не найден в токене");
            }

            if (!bool.TryParse(isDmClaim.Value, out bool isDm))
            {
                throw new SecurityTokenException("IsDM пользователя в токене не является логическим");
            }

            return isDm;
        }
    }
}