using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            List<ArmorsEntity> armorsEntities = _context.Armors.ToList();
            List<ArmorResponse> armors = armorsEntities.Select(a => ArmorResponse.FromEntity(a)).ToList();
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
            List<WeaponsEntity> weaponsEntities = _context.Weapons.ToList();
            List<WeaponResponse> weapons = weaponsEntities.Select(w => WeaponResponse.FromEntity(w)).ToList();
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
            List<PotionEntity> potionEntities = _context.Potion.ToList();
            List<PotionResponse> potions = potionEntities.Select(p => PotionResponse.FromEntity(p)).ToList();
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
            List<OthersEntity> othersEntities = _context.Others.ToList();
            List<OtherResponse> others = othersEntities.Select(o => OtherResponse.FromEntity(o)).ToList();
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
            List<FoodsEntity> foodsEntities = _context.Foods.ToList();
            List<FoodResponse> foods = _context.Foods.ToList().Select(f => FoodResponse.FromEntity(f)).ToList();
            return Ok(new
            {
                foods
            });
        }
    }
}