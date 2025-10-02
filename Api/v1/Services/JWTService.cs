// using System.Security.Claims;

// namespace DNDApi.Api.v1.Services
// {
//     public class JwtService
//     {
//         private readonly IConfiguration _configuration;

//         public JwtService(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }

//         public string GenerateToken(int userId, bool isDm)
//         {
//             var claims = new[]
//             {
//                 new Claim(ClaimTypes.NameIdentifier, userId.ToString),
//                 new Claim(ClaimTypes.Role, isDm ? "DM" : "Player"),
//                 new Claim("isDm", isDm.ToString())
//             };

//             var key = new SymmetricSe
//         }
//     }
// }