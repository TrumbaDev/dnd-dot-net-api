using DNDApi.Api.v1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers.DM
{
    [ApiController]
    [Route("api/v1/dm/[controller]")]
    public class ItemsController : DMBaseController
    {
        [HttpDelete("hero/delete-item")]
        [Authorize]
        public IActionResult DeleteHeroItem([FromQuery] int heroId, [FromQuery] string itemType, [FromQuery] int itemId)
        {
            bool isDm = JwtService.GetUserIsDmFromPrincipal(User);
            return Ok(new
            {
                dm = isDm
            });
        }
    }
}