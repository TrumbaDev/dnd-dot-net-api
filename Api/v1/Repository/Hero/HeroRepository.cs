using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Exceptions;
using DNDApi.Api.v1.Models.Entities.Hero;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Repository.Hero
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroDbContext _context;

        public HeroRepository(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<HeroEntity> GetByHeroIdWithParams(int heroId, int userId)
        {
            return await _context.Hero
                .Include(h => h.Params)
                .Where(h => h.HeroId == heroId && h.UserId == userId)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Hero not found");
        }

        public List<HeroEntity> GetByUserIdWithParams(int userId)
        {
            return _context.Hero
                .Include(h => h.Params)
                .Where(h => h.UserId == userId)
                .ToList();
        }
    }
}