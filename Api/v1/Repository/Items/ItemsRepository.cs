using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.Data;
using DNDApi.Api.v1.Models.Entities.Items;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Repository.Items
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly ItemsDbContext _context;

        public ItemsRepository(ItemsDbContext context)
        {
            _context = context;
        }

        public List<ArmorsEntity> GetAllArmors()
        {
            return _context.Armors.ToList();
        }

        public List<WeaponsEntity> GetAllWeapons()
        {
            return _context.Weapons.ToList();
        }

        public List<PotionEntity> GetAllPotion()
        {
            return _context.Potion.ToList();
        }

        public List<FoodsEntity> GetAllFood()
        {
            return _context.Foods.ToList();
        }

        public List<OthersEntity> GetAllOther()
        {
            return _context.Others.ToList();
        }

        public Task<List<PlayerItemsEntity>> GetHeroItemsAsync(int heroId, int userId)
        {
            return _context.PlayerItems
                .Where(i => i.HeroId == heroId && i.PlayerId == userId)
                .Include(pi => pi.Armor)
                .Include(pi => pi.Weapon)
                .Include(pi => pi.Potion)
                .Include(pi => pi.Food)
                .Include(pi => pi.Other)
                .ToListAsync();
        }
    }
}