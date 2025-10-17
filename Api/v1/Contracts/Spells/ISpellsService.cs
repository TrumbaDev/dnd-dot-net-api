using DNDApi.Api.v1.DTO.Spells;

namespace DNDApi.Api.v1.Contracts.Spells
{
    public interface ISpellsService
    {
        Task<PlayerSpellsResponse> GetHeroSpellsAsync(int heroId, int userId);
    }
}