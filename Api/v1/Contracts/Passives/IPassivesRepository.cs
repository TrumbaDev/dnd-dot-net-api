using DNDApi.Api.v1.Models.Entities.Passives;

namespace DNDApi.Api.v1.Contracts.Passives
{
    public interface IPassivesRepository
    {
        List<PlayerPassivesEntity> GetHeroPassives(int heroId, int userId);
        Task<List<PlayerPassivesEntity>> GetHeroesPassivesAsync(List<int> heroIds, int userId);
    }
}