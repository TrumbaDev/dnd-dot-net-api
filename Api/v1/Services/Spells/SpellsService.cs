using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Models.Entities.Spells;

namespace DNDApi.Api.v1.Services.Spells
{
    public class SpellsService
    {
        public PlayerSpellsResponse MapSpells(List<PlayerSpellsEntity> playerSpells)
        {
            List<SpellResponse> spells = playerSpells
                .Where(ps => ps.Spell is not null)
                .Select(ps => SpellResponse.FromEntity(ps.Spell!))
                .ToList();

            return new PlayerSpellsResponse
            {
                Spells = spells
            };
        }
    }
}