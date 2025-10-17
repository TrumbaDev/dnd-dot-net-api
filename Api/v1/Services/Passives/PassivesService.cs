using DNDApi.Api.v1.Contracts.Passives;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.Passive;
using DNDApi.Api.v1.Models.Entities.Passive;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Services.Passives
{
    public class PassivesService : IPassivesService
    {
        private readonly PassiveDbContext _context;

        public PassivesService(PassiveDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerPassiveResponse> GetHeroPassivesAsync(int heroId, int userId)
        {
            List<PlayerPassivesEntity> playerPassives = await _context.PlayerPassives
                .Where(p => p.HeroId == heroId && p.PlayerId == userId)
                .Include(p => p.Passive)
                .ToListAsync();

            return MapPassives(playerPassives);
        }

        private PlayerPassiveResponse MapPassives(List<PlayerPassivesEntity> playerPassives)
        {
            List<PassiveResponse> passives = playerPassives
                .Where(p => p.Passive != null)
                .Select(p => PassiveResponse.FromEntity(p.Passive))
                .ToList();

            return new PlayerPassiveResponse
            {
                Passives = passives
            };
        }
    }
}