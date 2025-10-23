using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.Contracts.Items
{
    public interface IItemsRepository
    {
        List<ArmorsEntity> GetAllArmors();
        List<WeaponsEntity> GetAllWeapons();
        List<PotionEntity> GetAllPotion();
        List<FoodsEntity> GetAllFood();
        List<OthersEntity> GetAllOther();
        Task<List<PlayerItemsEntity>> GetHeroItemsAsync(int heroId, int userId);
        Task<List<PlayerItemsEntity>> GetHeroesItemsAsync(List<int> heroIds, int userId);
    }
}