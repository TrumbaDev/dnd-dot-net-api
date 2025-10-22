using DNDApi.Api.v1.Models.Entities.Enumers;

namespace DNDApi.Api.v1.Contracts.Enumers
{
    public interface IEnumersRepository
    {
        Task<List<ClassEnumerEnity>> GetClassEnumersAsync();
        Task<List<RaceEnumerEnity>> GetRaceEnumersAsync();
    }
}