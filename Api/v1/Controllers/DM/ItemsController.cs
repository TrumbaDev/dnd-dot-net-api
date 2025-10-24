using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers.DM
{
    [ApiController]
    [Route("api/v1/dm[controller]")]
    public class ItemsController : ControllerBase
    {
        [HttpDelete]
        [Authorize]
        [Route("/hero/deleteItem")]
        public IActionResult DeleteHeroItem([FromQuery] int heroId, [FromQuery] string itemType, [FromQuery] int itemId)
        {
            return Ok(new { });
        }
    }
}