using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Spells;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Repository.Spells
{
    public class SpellsRepository : ISpellsRepository
    {
        private readonly SpellsDbContext _context;

        public SpellsRepository(SpellsDbContext context)
        {
            _context = context;
        }

        public List<PlayerSpellsEntity> GetHeroSpells(int heroId, int userId)
        {
            return _context.PlayerSpells
                .Where(s => s.HeroId == heroId && s.PlayerId == userId)
                .Include(ps => ps.Spell)
                .ToList();
        }

        public async Task<List<PlayerSpellsEntity>> GetHeroesSpellsAsync(List<int> heroIds, int userId)
        {
            return await _context.PlayerSpells
                .Where(s => heroIds.Contains(s.HeroId) && s.PlayerId == userId)
                .Include(ps => ps.Spell)
                .ToListAsync();
        }
    }
}