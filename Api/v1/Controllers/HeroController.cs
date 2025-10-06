// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace DNDApi.Api.v1.Controllers
// {
//     [ApiController]
//     [Route("api/v1/[controller]")]
//     public class HeroController : ControllerBase
//     {
//         [HttpGet]
//         [Authorize]
//         [Route("hero/{id}")]
//         public IActionResult GetHero(int id)
//         {
//             try
//             {

//             }
//             catch (System.Exception ex)
//             {
//                 return StatusCode(500, new
//                 {
//                     success = false,
//                     message = "Error durring authentication",
//                     error = ex.Message,
//                     details = ex.InnerException?.Message
//                 });
//             }
//         }
//     }
// }