using DNDApi.Api.v1.Models.Entities.Spells;

namespace DNDApi.Api.v1.DTO.Spells
{
    public class SpellResponse
    {
        public int Id { get; set; }
        public string SpellName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public static SpellResponse FromEntity(SpellsEntity entity)
        {
            return new SpellResponse
            {
                Id = entity.Id,
                SpellName = entity.SpellName,
                Description = entity.Description
            };
        }
    }
}