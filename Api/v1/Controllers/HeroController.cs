using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Contracts.Passives;
using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.DTO.Passives;
using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Services;
using DNDApi.Api.v1.Services.Items;
using DNDApi.Api.v1.Services.Passives;
using DNDApi.Api.v1.Services.Spells;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNDApi.Api.v1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _service;
        private readonly ItemsService _itemsService;
        private readonly PassivesService _passivesService;
        private readonly SpellsService _spellsService;
        private readonly IItemsRepository _itemsRepository;
        private readonly ISpellsRepository _spellsRepository;
        private readonly IPassivesRepository _passivesRepository;

        public HeroController(
            IHeroService service,
            ItemsService itemsService,
            PassivesService passivesService,
            SpellsService spellsService,
            IItemsRepository itemsRepository,
            ISpellsRepository spellsRepository,
            IPassivesRepository passivesRepository
        )
        {
            _service = service;
            _itemsService = itemsService;
            _passivesService = passivesService;
            _spellsService = spellsService;
            _itemsRepository = itemsRepository;
            _spellsRepository = spellsRepository;
            _passivesRepository = passivesRepository;
        }

        [HttpGet]
        [Authorize]
        [Route("full-hero/{heroId}")]
        public IActionResult GetHero(int heroId)
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);

            return Ok(new
            {
                hero = _service.GetById(heroId, userId)
            });
        }

        [HttpGet]
        [Authorize]
        [Route("items/{heroId}")]
        public IActionResult GetHeroItems(int heroId)
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);

            PlayerItemsResponse mappedItems = _itemsService.MapItems(_itemsRepository.GetHeroItems(heroId, userId));

            return Ok(new
            {
                armors = mappedItems.Armors,
                weapons = mappedItems.Weapons,
                potions = mappedItems.Potions,
                foods = mappedItems.Foods,
                others = mappedItems.Others
            });
        }

        [HttpGet]
        [Authorize]
        [Route("spells/{heroId}")]
        public IActionResult GetHeroSpells(int heroId)
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);

            PlayerSpellsResponse mappedSpells = _spellsService.MapSpells(_spellsRepository.GetHeroSpells(heroId, userId));

            return Ok(new
            {
                spells = mappedSpells.Spells
            });
        }

        [HttpGet]
        [Authorize]
        [Route("passives/{heroId}")]
        public IActionResult GetHeroPassives(int heroId)
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);

            PlayerPassivesReponse mappedPassives = _passivesService.MapPassives(_passivesRepository.GetHeroPassives(heroId, userId));
            return Ok(new
            {
                passives = mappedPassives.Passives
            });
        }

        [HttpGet]
        [Authorize]
        [Route("full-heroes")]
        public async Task<IActionResult> GetHeroesAsync()
        {
            int userId = JwtService.GetUserIdFromPrincipal(User);

            return Ok(new
            {
                heroes = await _service.GetHeroesAsync(userId)
            });
        }
    }
}