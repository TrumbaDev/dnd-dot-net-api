using DNDApi.Api.v1.Models.Entities.Hero;

namespace DNDApi.Api.v1.Contracts.Hero
{
    public interface IHeroService
    {
        Task<HeroEntity> GetById(int id);
    }
}