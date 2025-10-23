using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Hero
{
    [Table("parametrs")]
    public class ParamsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("player_id")]
        public int PlayerId { get; set; }

        [Required]
        [Column("hero_id")]
        public int HeroId { get; set; }

        [Column("speed")]
        public int Speed { get; set; }

        [Column("strength")]
        public int Strength { get; set; }

        [Column("agility")]
        public int Agility { get; set; }

        [Column("stamina")]
        public int Stamina { get; set; }

        [Column("intelligence")]
        public int Intelligence { get; set; }

        [Column("wisdom")]
        public int Wisdom { get; set; }

        [Column("charisma")]
        public int Charisma { get; set; }

        [Column("spasstrength")]
        public int SpasStrength { get; set; }

        [Column("spasagility")]
        public int SpasAgility { get; set; }

        [Column("spasstamina")]
        public int SpasStamina { get; set; }

        [Column("spasintelligence")]
        public int SpasIntelligence { get; set; }

        [Column("spaswisdom")]
        public int SpasWisdom { get; set; }

        [Column("spascharisma")]
        public int SpasCharisma { get; set; }

        [Column("acrobatics")]
        public int Acrobatics { get; set; }

        [Column("analysis")]
        public int Analysis { get; set; }

        [Column("athletics")]
        public int Athletics { get; set; }

        [Column("perception")]
        public int Perception { get; set; }

        [Column("survival")]
        public int Survival { get; set; }

        [Column("performance")]
        public int Performance { get; set; }

        [Column("intimidation")]
        public int Intimidation { get; set; }

        [Column("history")]
        public int History { get; set; }

        [Column("sleightofhand")]
        public int SleightOfHand { get; set; }

        [Column("magic")]
        public int Magic { get; set; }

        [Column("medicine")]
        public int Medicine { get; set; }

        [Column("deception")]
        public int Deception { get; set; }

        [Column("nature")]
        public int Nature { get; set; }

        [Column("insight")]
        public int Insight { get; set; }

        [Column("religion")]
        public int Religion { get; set; }

        [Column("stealth")]
        public int Stealth { get; set; }

        [Column("persuasion")]
        public int Persuasion { get; set; }

        [Column("animalhandling")]
        public int AnimalHandling { get; set; }

        [Column("bonus_ownership")]
        public int BonusOwnership { get; set; }

        [Column("dice_hit")]
        public int DiceHit { get; set; }

        [Column("num_dice_hit")]
        public int NumDiceHit { get; set; }

        public virtual HeroEntity? Hero { get; set; }
    }
}