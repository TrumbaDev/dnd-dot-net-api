
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.DTO.Spells;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroResponse
    {
        public int HeroID { get; set; }
        public int UserID { get; set; }
        public string Race { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
        public string HeroSide { get; set; } = string.Empty;
        public string HeroBorn { get; set; } = string.Empty;
        public string HeroHistory { get; set; } = string.Empty;
        public string HeroAvatar { get; set; } = string.Empty;
        public ParamsResponse HeroParams { get; set; } = new();
        public List<SpellResponse> HeroSpells { get; set; } = [];
        public List<ArmorResponse> HeroArmors { get; set; } = [];
        public List<WeaponResponse> HeroWeapons { get; set; } = [];
        public List<OtherResponse> HeroOthers { get; set; } = [];
        public List<PotionResponse> HeroPotions { get; set; } = [];
        public List<FoodResponse> HeroFoods { get; set; } = [];
    }
}