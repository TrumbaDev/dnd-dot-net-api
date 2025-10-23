using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Models.Entities.Hero;
using DNDApi.Api.v1.Services.Items;
using DNDApi.Api.v1.Services.Spells;

namespace DNDApi.Api.v1.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly HeroDbContext _context;
        private readonly IHeroRepository _heroRepository;
        private readonly IItemsRepository _itemsRepository;
        private readonly ISpellsRepository _spellsRepository;
        private readonly ItemsService _itemsService;
        private readonly SpellsService _spellsService;

        public HeroService(
            HeroDbContext context,
            IHeroRepository heroRepository,
            IItemsRepository itemsRepository,
            ISpellsRepository spellsRepository,
            ItemsService itemsService,
            SpellsService spellsService)
        {
            _context = context;
            _heroRepository = heroRepository;
            _itemsRepository = itemsRepository;
            _spellsRepository = spellsRepository;
            _itemsService = itemsService;
            _spellsService = spellsService;
        }

        public async Task<HeroResponse> GetById(int id, int userId)
        {
            HeroEntity heroEntity = await _heroRepository.GetByHeroIdWithParams(id, userId);

            HeroResponse hero = new HeroResponse
            {
                HeroID = heroEntity.HeroId,
                UserID = heroEntity.UserId,
                Race = heroEntity.Race,
                HeroName = heroEntity.HeroName,
                HeroSide = heroEntity.HeroSide,
                HeroBorn = heroEntity.HeroBorn,
                HeroHistory = heroEntity.HeroHistory,
                HeroAvatar = heroEntity.HeroAvatar,
                HeroParams = heroEntity.Params != null ? ParamsResponse.FromEntity(heroEntity.Params) : new ParamsResponse()
            };

            PlayerSpellsResponse playerSpells = _spellsService.MapSpells(await _spellsRepository.GetHeroSpellsAsync(id, userId));
            hero.HeroSpells = playerSpells.Spells;

            PlayerItemsResponse playerItems = _itemsService.MapItems(await _itemsRepository.GetHeroItemsAsync(id, userId));
            hero.HeroArmors = playerItems.Armors;
            hero.HeroWeapons = playerItems.Weapons;
            hero.HeroPotions = playerItems.Potions;
            hero.HeroFoods = playerItems.Foods;
            hero.HeroOthers = playerItems.Others;

            return hero;
        }
    }
}