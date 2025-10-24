using DNDApi.Api.v1.DTO.Passives;
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
        public List<PassivesResponse> HeroPassives { get; set; } = [];
        public List<HeroArmorResponse> HeroArmors { get; set; } = [];
        public List<HeroWeaponResponse> HeroWeapons { get; set; } = [];
        public List<HeroOtherResponse> HeroOthers { get; set; } = [];
        public List<HeroPotionResponse> HeroPotions { get; set; } = [];
        public List<HeroFoodResponse> HeroFoods { get; set; } = [];
    }
}