using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly HeroDbContext _context;
        private readonly IItemsService _itemsService;
        private readonly ISpellsService _spellsService;

        public HeroService(HeroDbContext context, IItemsService itemsService, ISpellsService spellsService)
        {
            _context = context;
            _itemsService = itemsService;
            _spellsService = spellsService;
        }

        public async Task<HeroResponse> GetById(int id, int userId)
        {
            HeroResponse hero = await _context.Hero
                 .Where(h => h.HeroId == id && h.UserId == userId)
                 .Select(hero => new HeroResponse
                 {
                     HeroID = hero.HeroId,
                     UserID = hero.UserId,
                     Race = hero.Race,
                     HeroName = hero.HeroName,
                     HeroSide = hero.HeroSide,
                     HeroBorn = hero.HeroBorn,
                     HeroHistory = hero.HeroHistory,
                     HeroAvatar = hero.HeroAvatar,
                     HeroParams = _context.Params
                         .Where(p => p.HeroId == hero.HeroId)
                         .Select(p => ParamsResponse.FromEntity(p))
                         .FirstOrDefault() ?? new ParamsResponse()
                 })
                 .FirstOrDefaultAsync() ?? throw new NotFoundException($"Герой с ID {id} не найден");

            PlayerSpellsResponse playerSpells = await _spellsService.GetHeroSpellsAsync(id, userId);

            hero.HeroSpells = playerSpells.Spells;

            PlayerItemsResponse playerItems = await _itemsService.GetHeroItemsAsync(id, userId);

            hero.HeroArmors = playerItems.Armors;
            hero.HeroWeapons = playerItems.Weapons;
            hero.HeroPotions = playerItems.Potions;
            hero.HeroFoods = playerItems.Foods;
            hero.HeroOthers = playerItems.Others;

            return hero;
        }
    }
}