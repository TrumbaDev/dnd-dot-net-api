using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.Items
{
    public class PotionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static PotionResponse FromEntity(PotionEntity entity)
        {
            return new PotionResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
    }
}