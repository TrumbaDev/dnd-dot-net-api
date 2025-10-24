using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroFoodResponse
    {
        public FoodResponse Food { get; set; } = new();
        public int Amount { get; set; }

        public static HeroFoodResponse FromEntity(PlayerItemsEntity entity)
        {
            return new HeroFoodResponse
            {
                Food = FoodResponse.FromEntity(entity.Food!),
                Amount = entity.ItemAmount
            };
        }
    }
}