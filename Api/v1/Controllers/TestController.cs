// using DNDApi.Api.v1.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace DNDApi.Api.v1.Controllers
// {
//     [ApiController]
//     [Route("api/v1/[controller]")]
//     public class TestController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//         private readonly ILogger<TestController> _logger;

//         public TestController(ApplicationDbContext context, ILogger<TestController> logger)
//         {
//             _context = context;
//             _logger = logger;
//         }

//         // Простейший health-check
//         [HttpGet]
//         public IActionResult Get()
//         {
//             return Ok(new { message = "Hello from TestController", timestamp = DateTime.UtcNow });
//         }

//         // Диагностика базы данных
//         [HttpGet("debug-db")]
//         public async Task<IActionResult> DebugDatabase()
//         {
//             try
//             {
//                 var canConnect = await _context.Database.CanConnectAsync();

//                 var tables = await _context.Database.SqlQueryRaw<string>(
//                     "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' ORDER BY table_name"
//                 ).ToListAsync();

//                 var usersColumns = await _context.Database.SqlQueryRaw<string>(
//                     "SELECT column_name FROM information_schema.columns WHERE table_schema = 'public' AND table_name = 'users' ORDER BY ordinal_position"
//                 ).ToListAsync();

//                 var directUsers = await _context.Database.SqlQueryRaw<dynamic>(
//                     "SELECT * FROM users LIMIT 10"
//                 ).ToListAsync();

//                 return Ok(new
//                 {
//                     canConnect,
//                     tables,
//                     usersColumns,
//                     directUsersCount = directUsers.Count,
//                     directUsers
//                 });
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, new
//                 {
//                     error = ex.Message,
//                     innerError = ex.InnerException?.Message,
//                     stackTrace = ex.StackTrace
//                 });
//             }
//         }

//         // Получение всех пользователей
//         [HttpGet("users")]
//         public async Task<IActionResult> GetAllUsers()
//         {
//             try
//             {
//                 _logger.LogInformation("Attempting to retrieve users from database");

//                 if (_context == null)
//                 {
//                     _logger.LogError("DbContext is null");
//                     return StatusCode(500, new { error = "DbContext is not available" });
//                 }

//                 var canConnect = await _context.Database.CanConnectAsync();
//                 _logger.LogInformation("Database can connect: {CanConnect}", canConnect);

//                 if (!canConnect)
//                 {
//                     return StatusCode(500, new { error = "Cannot connect to database" });
//                 }

//                 var tables = await _context.Database.SqlQueryRaw<string>(
//                     "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'"
//                 ).ToListAsync();

//                 _logger.LogInformation("Available tables: {Tables}", string.Join(", ", tables));

//                 var users = await _context.Users
//                     .OrderBy(u => u.Id)
//                     .ToListAsync();

//                 _logger.LogInformation("Retrieved {Count} users", users.Count);

//                 return Ok(new
//                 {
//                     success = true,
//                     count = users.Count,
//                     users
//                 });
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Error retrieving users");
//                 return StatusCode(500, new
//                 {
//                     success = false,
//                     message = "Error retrieving users",
//                     error = ex.Message,
//                     details = ex.InnerException?.Message
//                 });
//             }
//         }
//     }
// }
