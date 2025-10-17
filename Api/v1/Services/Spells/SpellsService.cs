using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Models.Entities.Spells;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Services.Spells
{
    public class SpellsService : ISpellsService
    {
        private readonly SpellsDbContext _context;

        public SpellsService(SpellsDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerSpellsResponse> GetHeroSpellsAsync(int heroId, int userId)
        {
            List<PlayerSpellsEntity> playerSpells = await _context.PlayerSpells
                .Where(s => s.HeroId == heroId && s.PlayerId == userId)
                .Include(ps => ps.Spell)
                .ToListAsync();

            return MapSpells(playerSpells);
        }
        
        private PlayerSpellsResponse MapSpells(List<PlayerSpellsEntity> playerSpells)
        {
            List<SpellResponse> spells = playerSpells
                .Where(ps => ps.Spell != null)
                .Select(ps => SpellResponse.FromEntity(ps.Spell))
                .ToList();

            return new PlayerSpellsResponse
            {
                Spells = spells
            };
        }
    }
}