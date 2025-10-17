using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Spells
{
    [Table("spells")]
    public class SpellsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("spell_name")]
        [MaxLength(50)]
        public string SpellName { get; set; } = string.Empty;

        [Column("description")]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;
    }
}