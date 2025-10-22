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
    }
}