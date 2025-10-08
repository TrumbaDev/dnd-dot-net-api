using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.DTO.Items
{
    public class WeaponResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Subtype { get; set; } = string.Empty;
        public string WeaponProperties { get; set; } = string.Empty;
        public string DamageType { get; set; } = string.Empty;
        public int NumDice { get; set; }
        public int Dice { get; set; }
        public int TwoHandDice { get; set; }
        public int BonusDamage { get; set; }
        public int RangeNumDice { get; set; }
        public int RangeDice { get; set; }
        public int RangeBonus { get; set; }
        public int MinRangeDistance { get; set; }
        public int MaxRangeDistance { get; set; }
        public string SpellsListId { get; set; } = string.Empty;
        public string PassiveListId { get; set; } = string.Empty;
        public float Weight { get; set; }
        public string Cost { get; set; } = string.Empty;

        public static WeaponResponse FromEntity(WeaponsEntity entity)
        {
            return new WeaponResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Type = entity.Type,
                Subtype = entity.Subtype,
                WeaponProperties = entity.WeaponProperties,
                DamageType = entity.DamageType,
                NumDice = entity.NumDice,
                Dice = entity.Dice,
                TwoHandDice = entity.TwoHandDice,
                BonusDamage = entity.BonusDamage,
                RangeNumDice = entity.RangeNumDice,
                RangeDice = entity.RangeDice,
                RangeBonus = entity.RangeBonus,
                MinRangeDistance = entity.MinRangeDistance,
                MaxRangeDistance = entity.MaxRangeDistance,
                SpellsListId = entity.SpellsListId,
                PassiveListId = entity.PassiveListId,
                Weight = entity.Weight,
                Cost = entity.Cost
            };
        }
    }
}