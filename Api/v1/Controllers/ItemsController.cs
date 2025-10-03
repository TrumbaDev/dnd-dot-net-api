using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsDbContext _context;

        public ItemsController(ItemsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        [Route("all-armors")]
        public IActionResult GetAllArmors()
        {
            try
            {
                ArmorsEntity[] armors = _context.Armors.ToArray();
                return Ok(new
                {
                    success = true,
                    data = armors
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

        [HttpGet]
        [Authorize]
        [Route("all-weapons")]
        public IActionResult GetAllWeapons()
        {
            try
            {
                WeaponsEntity[] weapons = _context.Weapons.ToArray();
                return Ok(new
                {
                    success = true,
                    data = weapons
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