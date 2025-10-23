using DNDApi.Api.v1.Contracts.Spells;
using DNDApi.Api.v1.DTO.Spells;
using DNDApi.Api.v1.Models.Entities.Spells;

namespace DNDApi.Api.v1.Services.Spells
{
    public class SpellsService
    {
        private readonly ISpellsRepository _spellsRepository;

        public SpellsService(ISpellsRepository spellsRepository)
        {
            _spellsRepository = spellsRepository;
        }

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

        public async Task<Dictionary<int, PlayerSpellsResponse>> GetHeroesSpellsAsync(List<int> heroIds, int userId)
        {
            List<PlayerSpellsEntity> playerSpells = await _spellsRepository.GetHeroesSpellsAsync(heroIds, userId);

            return playerSpells
                .GroupBy(ps => ps.HeroId)
                .ToDictionary(
                    g => g.Key,
                    g => new PlayerSpellsResponse
                    {
                        Spells = g
                            .Where(ps => ps.Spell is not null)
                            .Select(ps => SpellResponse.FromEntity(ps.Spell!))
                            .ToList()
                    }
                );
        }
    }
}