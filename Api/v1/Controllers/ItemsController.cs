using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.DTO.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        [Route("all-armors")]
        public IActionResult GetAllArmors()
        {
            List<ArmorResponse> armors = _repository.GetAllArmors().Select(ArmorResponse.FromEntity).ToList();
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
            List<WeaponResponse> weapons = _repository.GetAllWeapons().Select(WeaponResponse.FromEntity).ToList();
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
            List<PotionResponse> potions = _repository.GetAllPotion().Select(PotionResponse.FromEntity).ToList();
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
            List<OtherResponse> others = _repository.GetAllOther().Select(OtherResponse.FromEntity).ToList();
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
            List<FoodResponse> foods = _repository.GetAllFood().Select(FoodResponse.FromEntity).ToList();
            return Ok(new
            {
                foods
            });
        }
    }
}