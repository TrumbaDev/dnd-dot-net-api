using DNDApi.Api.v1.Contracts.Passives;
using DNDApi.Api.v1.DTO.Passives;
using DNDApi.Api.v1.Models.Entities.Passives;

namespace DNDApi.Api.v1.Services.Passives
{
    public class PassivesService
    {
        private readonly IPassivesRepository _passivesRepository;

        public PassivesService(IPassivesRepository passivesRepository)
        {
            _passivesRepository = passivesRepository;
        }

        public PlayerPassivesReponse MapPassives(List<PlayerPassivesEntity> playerPassives)
        {
            List<PassivesResponse> passives = playerPassives
                    .Where(pp => pp.Passive is not null)
                    .Select(pp => PassivesResponse.FromEntity(pp.Passive!))
                    .ToList();

            return new PlayerPassivesReponse
            {
                Passives = passives
            };
        }

        public async Task<Dictionary<int, PlayerPassivesReponse>> GetHeroesPassivesAsync(List<int> heroIds, int userId)
        {
            List<PlayerPassivesEntity> playerPassives = await _passivesRepository.GetHeroesPassivesAsync(heroIds, userId);

            return playerPassives
                .GroupBy(pp => pp.HeroId)
                .ToDictionary(
                    g => g.Key,
                    g => MapPassives(g.ToList())
                );
        }
    }
}