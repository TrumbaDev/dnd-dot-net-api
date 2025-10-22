using DNDApi.Api.v1.DTO.Items;

namespace DNDApi.Api.v1.Contracts.Items
{
    public interface IItemsRepository
    {
        List<ArmorResponse> GetAllArmors();
        List<WeaponResponse> GetAllWeapons();
        List<PotionResponse> GetAllPotion();
        List<FoodResponse> GetAllFood();
        List<OtherResponse> GetAllOther();
    }
}