using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Hero;
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

        public async Task<HeroEntity> GetById(int id)
        {
            return await _context.Hero.Where(h => h.HeroId == id).FirstOrDefaultAsync();
        }
    }
}