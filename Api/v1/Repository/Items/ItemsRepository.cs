using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.Repository.Items
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ItemsDbContext _context;

        public ItemsRepository(ItemsDbContext context)
        {
            _context = context;
        }

        public List<ArmorResponse> GetAllArmors()
        {
            List<ArmorsEntity> armors = _context.Armors.ToList();
            return armors.Select(ArmorResponse.FromEntity).ToList();
        }

        public List<WeaponResponse> GetAllWeapons()
        {
            List<WeaponsEntity> weapons = _context.Weapons.ToList();
            return weapons.Select(WeaponResponse.FromEntity).ToList();
        }

        public List<PotionResponse> GetAllPotion()
        {
            List<PotionEntity> potions = _context.Potion.ToList();
            return potions.Select(PotionResponse.FromEntity).ToList();
        }

        public List<FoodResponse> GetAllFood()
        {
            List<FoodsEntity> foods = _context.Foods.ToList();
            return foods.Select(FoodResponse.FromEntity).ToList();
        }
        
        public List<OtherResponse> GetAllOther()
        {
            List<OthersEntity> others = _context.Others.ToList();
            return others.Select(OtherResponse.FromEntity).ToList();
        }
    }
}