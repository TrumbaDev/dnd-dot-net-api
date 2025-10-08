using DNDApi.Api.v1.Contracts.Hero;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.HeroDTO;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly HeroDbContext _context;

        public HeroService(HeroDbContext context)
        {
            _context = context;
        }

        public async Task<HeroResponse> GetById(int id, int userId)
        {
            // return await _context.Hero.Where(h => h.HeroId == id && h.UserId == userId).FirstOrDefaultAsync();
            HeroResponse heroDto = await _context.Hero
                .Where(h => h.HeroId == id && h.UserId == userId)
                .Select(hero => new HeroResponse
                {
                    HeroID = hero.HeroId,
                    UserID = hero.UserId,
                    Race = hero.Race,
                    HeroName = hero.HeroName,
                    HeroSide = hero.HeroSide,
                    HeroBorn = hero.HeroBorn,
                    HeroHistory = hero.HeroHistory,
                    HeroAvatar = hero.HeroAvatar,
                    HeroParams = _context.Params
                        .Where(p => p.HeroId == hero.HeroId)
                        .Select(p => new ParamsResponse
                        {
                            Id = p.Id,
                            PlayerId = p.PlayerId,
                            HeroId = p.HeroId,
                            Speed = p.Speed,
                            Strength = p.Strength,
                            Agility = p.Agility,
                            Stamina = p.Stamina,
                            Intelligence = p.Intelligence,
                            Wisdom = p.Wisdom,
                            Charisma = p.Charisma,
                            SpasStrength = p.SpasStrength,
                            SpasAgility = p.SpasAgility,
                            SpasStamina = p.SpasStamina,
                            SpasIntelligence = p.SpasIntelligence,
                            SpasWisdom = p.SpasWisdom,
                            SpasCharisma = p.SpasCharisma,
                            Acrobatics = p.Acrobatics,
                            Analysis = p.Analysis,
                            Athletics = p.Athletics,
                            Perception = p.Perception,
                            Survival = p.Survival,
                            Performance = p.Performance,
                            Intimidation = p.Intimidation,
                            History = p.History,
                            SleightOfHand = p.SleightOfHand,
                            Magic = p.Magic,
                            Medicine = p.Medicine,
                            Deception = p.Deception,
                            Nature = p.Nature,
                            Insight = p.Insight,
                            Religion = p.Religion,
                            Stealth = p.Stealth,
                            Persuasion = p.Persuasion,
                            AnimalHandling = p.AnimalHandling,
                            BonusOwnership = p.BonusOwnership,
                            DiceHit = p.DiceHit,
                            NumDiceHit = p.NumDiceHit
                        })
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            return heroDto;
        }
    }
}