using DNDApi.Api.v1.Models.Entities.Hero;

namespace DNDApi.Api.v1.Contracts.Hero
{
    public interface IHeroRepository
    {
        Task<HeroEntity> GetByHeroIdWithParams(int heroId, int userId);
        List<HeroEntity> GetByUserIdWithParams(int userId);
    }
}