using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroPotionResponse
    {
        public PotionResponse Potion { get; set; } = new();
        public int Amount { get; set; }

        public static HeroPotionResponse FromEntity(PlayerItemsEntity entity)
        {
            return new HeroPotionResponse
            {
                Potion = PotionResponse.FromEntity(entity.Potion!),
                Amount = entity.ItemAmount
            };
        }
    }
}