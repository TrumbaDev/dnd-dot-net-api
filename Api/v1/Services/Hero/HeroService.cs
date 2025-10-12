using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly HeroDbContext _context;
        private readonly ItemsDbContext _itemsContext;

        public HeroService(HeroDbContext context, ItemsDbContext itemsContext)
        {
            _context = context;
            _itemsContext = itemsContext;
        }

        public async Task<HeroEntity> GetById(int id, int userId)
        {
            return await _context.Hero
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
                         .FirstOrDefault() ?? new ParamsResponse(),
                     HeroArmors = _itemsContext.PlayerItems
                        .Where(i => i.HeroId == hero.HeroId && i.PlayerId == userId && i.ItemType == "armor")
                        .Include(pi => pi.Armor)
                        .Select(pi => ArmorResponse.FromEntity(pi.Armor))
                        .ToList()
                 })
                 .FirstOrDefaultAsync() ?? throw new NotFoundException($"Герой с ID {id} не найден");
        }
    }
}