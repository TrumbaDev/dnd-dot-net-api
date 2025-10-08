using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Items;
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
            ArmorsEntity[] armors = _context.Armors.ToArray();
            return Ok(new
            {
                armors
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-weapons")]
        public IActionResult GetAllWeapons()
        {
            WeaponsEntity[] weapons = _context.Weapons.ToArray();
            return Ok(new
            {
                weapons
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-potions")]
        public IActionResult GetAllPotions()
        {
            PotionEntity[] potions = _context.Potion.ToArray();
            return Ok(new
            {
                potions
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-others")]
        public IActionResult GetAllOthers()
        {
            OthersEntity[] others = _context.Others.ToArray();
            return Ok(new
            {
                others
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-foods")]
        public IActionResult GetAllFoods()
        {
            FoodsEntity[] foods = _context.Foods.ToArray();
            return Ok(new
            {
                foods
            });
        }
    }
}