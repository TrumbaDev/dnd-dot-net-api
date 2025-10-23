using DNDApi.Api.v1.Contracts.Items;
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
            List<ArmorResponse> armors = playerItems
                .Where(pi => pi.ItemType == "armor" && pi.Armor != null)
                .Select(pi => ArmorResponse.FromEntity(pi.Armor!))
                .ToList();

            List<WeaponResponse> weapons = playerItems
                .Where(pi => pi.ItemType == "weapon" && pi.Weapon != null)
                .Select(pi => WeaponResponse.FromEntity(pi.Weapon!))
                .ToList();

            List<PotionResponse> potions = playerItems
                .Where(pi => pi.ItemType == "potion" && pi.Potion != null)
                .Select(pi => PotionResponse.FromEntity(pi.Potion!))
                .ToList();

            List<FoodResponse> foods = playerItems
                .Where(pi => pi.ItemType == "food" && pi.Food != null)
                .Select(pi => FoodResponse.FromEntity(pi.Food!))
                .ToList();

            List<OtherResponse> others = playerItems
                .Where(pi => pi.ItemType == "other" && pi.Other != null)
                .Select(pi => OtherResponse.FromEntity(pi.Other!))
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