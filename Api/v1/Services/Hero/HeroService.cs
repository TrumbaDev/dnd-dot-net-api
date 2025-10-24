using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Contracts.Passives;
using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.DTO.Passives;
using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Models.Entities.Hero;
using DNDApi.Api.v1.Services.Items;
using DNDApi.Api.v1.Services.Passives;
using DNDApi.Api.v1.Services.Spells;

namespace DNDApi.Api.v1.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IItemsRepository _itemsRepository;
        private readonly ISpellsRepository _spellsRepository;
        private readonly IPassivesRepository _passivesRepository;
        private readonly ItemsService _itemsService;
        private readonly SpellsService _spellsService;
        private readonly PassivesService _passivesService;

        public HeroService(
            IHeroRepository heroRepository,
            IItemsRepository itemsRepository,
            ISpellsRepository spellsRepository,
            IPassivesRepository passivesRepository,
            ItemsService itemsService,
            SpellsService spellsService,
            PassivesService passivesService
            )
        {
            _heroRepository = heroRepository;
            _itemsRepository = itemsRepository;
            _spellsRepository = spellsRepository;
            _passivesRepository = passivesRepository;
            _itemsService = itemsService;
            _spellsService = spellsService;
            _passivesService = passivesService;
        }

        public HeroResponse GetById(int id, int userId)
        {
            HeroEntity heroEntity = _heroRepository.GetByHeroIdWithParams(id, userId);

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

            PlayerSpellsResponse playerSpells = _spellsService.MapSpells(_spellsRepository.GetHeroSpells(id, userId));
            hero.HeroSpells = playerSpells.Spells;

            PlayerPassivesReponse playerPassives = _passivesService.MapPassives(_passivesRepository.GetHeroPassives(id, userId));
            hero.HeroPassives = playerPassives.Passives;

            PlayerItemsResponse playerItems = _itemsService.MapItems(_itemsRepository.GetHeroItems(id, userId));
            hero.HeroArmors = playerItems.Armors;
            hero.HeroWeapons = playerItems.Weapons;
            hero.HeroPotions = playerItems.Potions;
            hero.HeroFoods = playerItems.Foods;
            hero.HeroOthers = playerItems.Others;

            return hero;
        }

        public async Task<List<HeroResponse>> GetHeroesAsync(int userId)
        {
            List<HeroEntity> heroesEntities = _heroRepository.GetByUserIdWithParams(userId);

            List<int> heroIds = heroesEntities.Select(h => h.HeroId).ToList();

            Task<Dictionary<int, PlayerSpellsResponse>> spellsTask = _spellsService.GetHeroesSpellsAsync(heroIds, userId);
            Task<Dictionary<int, PlayerPassivesReponse>> passivesTak = _passivesService.GetHeroesPassivesAsync(heroIds, userId);
            Task<Dictionary<int, PlayerItemsResponse>> itemsTask = _itemsService.GetHeroesItemsAsync(heroIds, userId);

            await Task.WhenAll(spellsTask, itemsTask);

            Dictionary<int, PlayerSpellsResponse> allSpells = spellsTask.Result;
            Dictionary<int, PlayerPassivesReponse> allPassives = passivesTak.Result;
            Dictionary<int, PlayerItemsResponse> allItems = itemsTask.Result;

            return heroesEntities.Select(heroEntity => new HeroResponse
            {
                HeroID = heroEntity.HeroId,
                UserID = heroEntity.UserId,
                Race = heroEntity.Race,
                HeroName = heroEntity.HeroName,
                HeroSide = heroEntity.HeroSide,
                HeroBorn = heroEntity.HeroBorn,
                HeroHistory = heroEntity.HeroHistory,
                HeroAvatar = heroEntity.HeroAvatar,
                HeroParams = heroEntity.Params != null ? ParamsResponse.FromEntity(heroEntity.Params) : new ParamsResponse(),
                HeroSpells = allSpells.GetValueOrDefault(heroEntity.HeroId)?.Spells ?? [],
                HeroPassives = allPassives.GetValueOrDefault(heroEntity.HeroId)?.Passives ?? [],
                HeroArmors = allItems.GetValueOrDefault(heroEntity.HeroId)?.Armors ?? [],
                HeroWeapons = allItems.GetValueOrDefault(heroEntity.HeroId)?.Weapons ?? [],
                HeroPotions = allItems.GetValueOrDefault(heroEntity.HeroId)?.Potions ?? [],
                HeroFoods = allItems.GetValueOrDefault(heroEntity.HeroId)?.Foods ?? [],
                HeroOthers = allItems.GetValueOrDefault(heroEntity.HeroId)?.Others ?? []
            }).ToList();
        }

        public List<HeroResponse> GetHeroesLight(int userId)
        {
            List<HeroEntity> heroesEntities = _heroRepository.GetByUserId(userId);

            return heroesEntities.Select(heroEntity => new HeroResponse
            {
                HeroID = heroEntity.HeroId,
                UserID = heroEntity.UserId,
                Race = heroEntity.Race,
                HeroName = heroEntity.HeroName,
                HeroSide = heroEntity.HeroSide,
                HeroBorn = heroEntity.HeroBorn,
                HeroHistory = heroEntity.HeroHistory,
                HeroAvatar = heroEntity.HeroAvatar
            }).ToList();
        }
    }
}