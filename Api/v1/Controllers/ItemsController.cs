using DNDApi.Api.v1.Contracts.Items;
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
            return Ok(new
            {
                armors = _repository.GetAllArmors()
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-weapons")]
        public IActionResult GetAllWeapons()
        {
            return Ok(new
            {
                weapons = _repository.GetAllWeapons()
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-potions")]
        public IActionResult GetAllPotions()
        {
            return Ok(new
            {
                potions = _repository.GetAllPotion()
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-others")]
        public IActionResult GetAllOthers()
        {
            return Ok(new
            {
                others = _repository.GetAllOther()
            });
        }

        [HttpGet]
        [Authorize]
        [Route("all-foods")]
        public IActionResult GetAllFoods()
        {
            return Ok(new
            {
                foods = _repository.GetAllFood()
            });
        }
    }
}