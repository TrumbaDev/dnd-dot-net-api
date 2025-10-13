using DNDApi.Api.v1.DTO.Items;

namespace DNDApi.Api.v1.Contracts.Items
{
    public interface IItemsService
    {
        Task<PlayerItemsResponse> GetHeroItemsAsync(int heroID, int userId);
    }
}