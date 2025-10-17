using DNDApi.Api.v1.DTO.Passive;

namespace DNDApi.Api.v1.Contracts.Passives
{
    public interface IPassivesService
    {
        Task<PlayerPassiveResponse> GetHeroPassivesAsync(int heroId, int userId);
    }
}