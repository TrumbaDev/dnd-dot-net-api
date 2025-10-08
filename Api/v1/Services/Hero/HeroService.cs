using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly HeroDbContext _context;

        public HeroService(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<HeroResponse> GetById(int id, int userId)
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
                         .FirstOrDefault() ?? new ParamsResponse()
                 })
                 .FirstOrDefaultAsync() ?? throw new NotFoundException($"Герой с ID {id} не найден");
        }
    }
}