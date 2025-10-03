using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Items
{
    public class WeaponsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(256)]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("subtype")]
        public string Subtype { get; set; } = string.Empty;

        [MaxLength(300)]
        [Column("weaponproperties")]
        public string WeaponProperties { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("damagetype")]
        public string DamageType { get; set; } = string.Empty;

        [Column("numdice")]
        public int NumDice { get; set; }

        [Column("dice")]
        public int Dice { get; set; }

        [Column("twohanddice")]
        public int TwoHandDice { get; set; }

        [Column("bonusdamage")]
        public int BonusDamage { get; set; }

        [Column("rangenumdice")]
        public int RangeNumDice { get; set; }

        [Column("rangedice")]
        public int RangeDice { get; set; }

        [Column("rangebonus")]
        public int RangeBonus { get; set; }

        [Column("minrangedistance")]
        public int MinRangeDistance { get; set; }

        [Column("maxrangedistance")]
        public int MaxRangeDistance { get; set; }

        [MaxLength(50)]
        [Column("spellslistid")]
        public string SpellsListId { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("passiveslistid")]
        public string PassiveListId { get; set; } = string.Empty;

        [Column("weight")]
        public float Weight { get; set; }

        [MaxLength(10)]
        [Column("cost")]
        public string Cost { get; set; } = string.Empty;
    }
}