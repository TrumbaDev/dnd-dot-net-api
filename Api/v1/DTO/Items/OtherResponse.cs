using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.Items
{
    public class OtherResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static OtherResponse FromEntity(OthersEntity entity)
        {
            return new OtherResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
    }
}