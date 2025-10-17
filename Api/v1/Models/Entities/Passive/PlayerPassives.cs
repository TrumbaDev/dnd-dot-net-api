using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Passive
{
    [Table("player_passives")]
    public class PlayerPassivesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("passive_id")]
        public int PassiveId { get; set; }

        [Required]
        [Column("player_id")]
        public int PlayerId { get; set; }

        [Required]
        [Column("hero_id")]
        public int HeroId { get; set; }

        public virtual PassiveEntity? Passive { get; set; }
    }
}