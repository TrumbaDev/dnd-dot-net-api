using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNDApi.Api.v1.Models.Entities.Items
{
    [Table("player_items")]
    public class PlayerItemsEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("item_id")]
        public int ItemId { get; set; }

        [Required]
        [Column("player_id")]
        public int PlayerId { get; set; }

        [Required]
        [Column("hero_id")]
        public int HeroId { get; set; }

        [Column("item_amount")]
        public int ItemAmount { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("itemtype")]
        public string ItemType { get; set; } = string.Empty;

        public virtual ArmorsEntity? Armor { get; set; }
        public virtual WeaponsEntity? Weapon { get; set; }
        public virtual PotionEntity? Potion { get; set; }
        public virtual FoodsEntity? Food { get; set; }
        public virtual OthersEntity? Other { get; set; }
    }
}