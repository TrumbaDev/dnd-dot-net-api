using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Enumers
{
    public class ClassEnumerEnity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("name_ru")]
        public string NameRu { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("name_en")]
        public string NameEn { get; set; }

        [MaxLength(500)]
        [Column("description")]
        public string Description { get; set; }
    }
}