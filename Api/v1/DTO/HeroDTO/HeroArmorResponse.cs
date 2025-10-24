using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroArmorResponse
    {
        public ArmorResponse Armor { get; set; } = new();
        public int Amount { get; set; }

        public static HeroArmorResponse FromEntity(PlayerItemsEntity entity)
        {
            return new HeroArmorResponse
            {
                Armor = ArmorResponse.FromEntity(entity.Armor!),
                Amount = entity.ItemAmount
            };
        }
    }
}