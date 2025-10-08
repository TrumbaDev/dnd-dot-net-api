using DNDApi.Api.v1.DTO.HeroDTO;

namespace DNDApi.Api.v1.Contracts.Hero
{
    public interface IHeroService
    {
        Task<HeroResponse> GetById(int heroId, int userId);
    }
}