
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Passives
{
    public class PassivesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("ability_name")]
        public string AbilityName { get; set; } = string.Empty;

        [MaxLength(2000)]
        [Column("description")]
        public string Description { get; set; } = string.Empty;
    }
}