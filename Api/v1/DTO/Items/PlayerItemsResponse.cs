namespace DNDApi.Api.v1.DTO.Items
{
    public class PlayerItemsResponse
    {
        public List<ArmorResponse> Armors = [];
        public List<WeaponResponse> Weapons = [];
        public List<PotionResponse> Potions = [];
        public List<FoodResponse> Foods = [];
        public List<OtherResponse> Others = [];
    }
}