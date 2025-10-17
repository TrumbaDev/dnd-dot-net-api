using DNDApi.Api.v1.Models.Entities.Passive;

namespace DNDApi.Api.v1.DTO.Passive
{
    public class PassiveResponse
    {
        public int Id { get; set; }
        public string PassiveName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static PassiveResponse FromEntity(PassiveEntity entity)
        {
            return new PassiveResponse
            {
                Id = entity.Id,
                PassiveName = entity.AbilityName,
                Description = entity.Description
            };
        }
    }
}