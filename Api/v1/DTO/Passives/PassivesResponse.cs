using DNDApi.Api.v1.Models.Entities.Passives;

namespace DNDApi.Api.v1.DTO.Passives
{
    public class PassivesResponse
    {
        public int Id { get; set; }
        public string AbilityName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static PassivesResponse FromEntity(PassivesEntity entity)
        {
            return new PassivesResponse
            {
                Id = entity.Id,
                AbilityName = entity.AbilityName,
                Description = entity.Description
            };
        }
    }
}