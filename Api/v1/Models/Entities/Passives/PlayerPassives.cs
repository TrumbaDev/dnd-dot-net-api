using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Passives
{   
    [Table("player_passive")]
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

        public virtual PassivesEntity? Passive { get; set; }
    }
}