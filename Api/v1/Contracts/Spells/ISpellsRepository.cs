using DNDApi.Api.v1.Models.Entities.Spells;

namespace DNDApi.Api.v1.Contracts.Spells
{
    public interface ISpellsRepository
    {
        Task<List<PlayerSpellsEntity>> GetHeroSpellsAsync(int heroId, int userId);
        Task<List<PlayerSpellsEntity>> GetHeroesSpellsAsync(List<int> heroIds, int userId);
    }
}