using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroWeaponResponse
    {
        public WeaponResponse Weapon { get; set; } = new();
        public int Amount { get; set; }

        public static HeroWeaponResponse FromEntity(PlayerItemsEntity entity)
        {
            return new HeroWeaponResponse
            {
                Weapon = WeaponResponse.FromEntity(entity.Weapon!),
                Amount = entity.ItemAmount
            };
        }
    }
}