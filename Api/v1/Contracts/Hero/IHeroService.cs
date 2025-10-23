using DNDApi.Api.v1.DTO.HeroDTO;

namespace DNDApi.Api.v1.Contracts.Hero
{
    public interface IHeroService
    {
        HeroResponse GetById(int heroId, int userId);

        Task<List<HeroResponse>> GetHeroesAsync(int userId);
    }
}