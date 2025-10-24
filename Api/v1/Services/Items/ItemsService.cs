using DNDApi.Api.v1.Contracts.Items;
using DNDApi.Api.v1.DTO.HeroDTO;
using DNDApi.Api.v1.DTO.Items;
using DNDApi.Api.v1.Models.Entities.Items;

namespace DNDApi.Api.v1.Services.Items
{
    public class ItemsService
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsService(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public PlayerItemsResponse MapItems(List<PlayerItemsEntity> playerItems)
        {
            List<HeroArmorResponse> armors = playerItems
                .Where(pi => pi.ItemType == "armor" && pi.Armor != null)
                .Select(pi => HeroArmorResponse.FromEntity(pi!))
                .ToList();

            List<HeroWeaponResponse> weapons = playerItems
                .Where(pi => pi.ItemType == "weapon" && pi.Weapon != null)
                .Select(pi => HeroWeaponResponse.FromEntity(pi!))
                .ToList();

            List<HeroPotionResponse> potions = playerItems
                .Where(pi => pi.ItemType == "potion" && pi.Potion != null)
                .Select(pi => HeroPotionResponse.FromEntity(pi!))
                .ToList();

            List<HeroFoodResponse> foods = playerItems
                .Where(pi => pi.ItemType == "food" && pi.Food != null)
                .Select(pi => HeroFoodResponse.FromEntity(pi!))
                .ToList();

            List<HeroOtherResponse> others = playerItems
                .Where(pi => pi.ItemType == "other" && pi.Other != null)
                .Select(pi => HeroOtherResponse.FromEntity(pi!))
                .ToList();

            return new PlayerItemsResponse
            {
                Armors = armors,
                Weapons = weapons,
                Potions = potions,
                Foods = foods,
                Others = others
            };
        }

        public async Task<Dictionary<int, PlayerItemsResponse>> GetHeroesItemsAsync(List<int> heroIds, int userId)
        {
            List<PlayerItemsEntity> playerItems = await _itemsRepository.GetHeroesItemsAsync(heroIds, userId);

            return playerItems
                .GroupBy(pi => pi.HeroId)
                .ToDictionary(
                    g => g.Key,
                    g => MapItems(g.ToList())
                );
        }
    }
}