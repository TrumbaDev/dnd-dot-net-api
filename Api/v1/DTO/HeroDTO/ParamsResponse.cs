using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DNDApi.Api.v1.Models.Entities.Hero;

namespace DNDApi.Api.v1.DTO.HeroDTO
{
    public class ParamsResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [Required]
        public int HeroId { get; set; }

        // Основные характеристики
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        // Спасброски
        public int SpasStrength { get; set; }
        public int SpasAgility { get; set; }
        public int SpasStamina { get; set; }
        public int SpasIntelligence { get; set; }
        public int SpasWisdom { get; set; }
        public int SpasCharisma { get; set; }

        // Навыки
        public int Acrobatics { get; set; }
        public int Analysis { get; set; }
        public int Athletics { get; set; }
        public int Perception { get; set; }
        public int Survival { get; set; }
        public int Performance { get; set; }
        public int Intimidation { get; set; }
        public int History { get; set; }
        public int SleightOfHand { get; set; }
        public int Magic { get; set; }
        public int Medicine { get; set; }
        public int Deception { get; set; }
        public int Nature { get; set; }
        public int Insight { get; set; }
        public int Religion { get; set; }
        public int Stealth { get; set; }
        public int Persuasion { get; set; }
        public int AnimalHandling { get; set; }

        // Прочее
        public int BonusOwnership { get; set; }
        public int DiceHit { get; set; }
        public int NumDiceHit { get; set; }
        
        public static ParamsResponse FromEntity(ParamsEntity entity)
        {
            return new ParamsResponse
            {
                Id = entity.Id,
                PlayerId = entity.PlayerId,
                HeroId = entity.HeroId,
                Speed = entity.Speed,
                Strength = entity.Strength,
                Agility = entity.Agility,
                Stamina = entity.Stamina,
                Intelligence = entity.Intelligence,
                Wisdom = entity.Wisdom,
                Charisma = entity.Charisma,
                SpasStrength = entity.SpasStrength,
                SpasAgility = entity.SpasAgility,
                SpasStamina = entity.SpasStamina,
                SpasIntelligence = entity.SpasIntelligence,
                SpasWisdom = entity.SpasWisdom,
                SpasCharisma = entity.SpasCharisma,
                Acrobatics = entity.Acrobatics,
                Analysis = entity.Analysis,
                Athletics = entity.Athletics,
                Perception = entity.Perception,
                Survival = entity.Survival,
                Performance = entity.Performance,
                Intimidation = entity.Intimidation,
                History = entity.History,
                SleightOfHand = entity.SleightOfHand,
                Magic = entity.Magic,
                Medicine = entity.Medicine,
                Deception = entity.Deception,
                Nature = entity.Nature,
                Insight = entity.Insight,
                Religion = entity.Religion,
                Stealth = entity.Stealth,
                Persuasion = entity.Persuasion,
                AnimalHandling = entity.AnimalHandling,
                BonusOwnership = entity.BonusOwnership,
                DiceHit = entity.DiceHit,
                NumDiceHit = entity.NumDiceHit
            };
        }
    }
}