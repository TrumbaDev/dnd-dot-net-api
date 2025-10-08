using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}