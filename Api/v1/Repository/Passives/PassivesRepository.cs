using DNDApi.Api.v1.Contracts.Passives;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Passives;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Repository.Passives
{
    public class PassivesRepository : IPassivesRepository
    {
        private readonly PassivesDbContext _context;

        public PassivesRepository(PassivesDbContext context)
        {
            _context = context;
        }

        public List<PlayerPassivesEntity> GetHeroPassives(int heroId, int userId)
        {
            return _context.PlayerPassives
                .Where(p => p.HeroId == heroId && p.PassiveId == userId)
                .Include(pp => pp.Passive)
                .ToList();
        }

        public async Task<List<PlayerPassivesEntity>> GetHeroesPassivesAsync(List<int> heroIds, int userId)
        {
            return await _context.PlayerPassives
                .Where(p => heroIds.Contains(p.HeroId) && p.PassiveId == userId)
                .Include(pp => pp.Passive)
                .ToListAsync();
        }
    }
}