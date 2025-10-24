using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class HeroOtherResponse
    {
        public OtherResponse Other { get; set; } = new();
        public int Amount { get; set; }

        public static HeroOtherResponse FromEntity(PlayerItemsEntity entity)
        {
            return new HeroOtherResponse
            {
                Other = OtherResponse.FromEntity(entity.Other!),
                Amount = entity.ItemAmount
            };
        }
    }
}