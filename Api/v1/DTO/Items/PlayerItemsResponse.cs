using DNDApi.Api.v1.DTO.HeroDTO;

namespace DNDApi.Api.v1.DTO.Items
{
    public class PlayerItemsResponse
    {
        public List<HeroArmorResponse> Armors = [];
        public List<HeroWeaponResponse> Weapons = [];
        public List<HeroPotionResponse> Potions = [];
        public List<HeroFoodResponse> Foods = [];
        public List<HeroOtherResponse> Others = [];
    }
}