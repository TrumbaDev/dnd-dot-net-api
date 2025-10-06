using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Hero
{
    [Table("heroes")]
    public class HeroEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("hero_id")]
        public int HeroId { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("race")]
        public string Race { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("hero_name")]
        public string HeroName { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("hero_side")]
        public string HeroSide { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("hero_born")]
        public string HeroBorn { get; set; } = string.Empty;

        [MaxLength(10000)]
        [Column("hero_history")]
        public string HeroHistory { get; set; } = string.Empty;

        [MaxLength(150)]
        [Column("hero_avatar")]
        public string HeroAvatar { get; set; } = string.Empty;
    }
}