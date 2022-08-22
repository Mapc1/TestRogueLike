using System.Collections.Generic;
using TestRogueLike.Exceptions.Characters.Players;
using TestRogueLike.Game.Items;

namespace TestRogueLike.Game.Characters.Players
{
    public class Inventory
    {
        private readonly int maxHotbarSize;
        private readonly int maxInventorySize;
        
        private List<Item> _hotbar;
        private List<Item> _inventory;

        private int activeItem;

        public Inventory(Item item, int hotbarSize = 10, int inventorySize = 10)
        {
            _hotbar = new List<Item> { item };
            _inventory = new List<Item>();

            activeItem = 0;
        }

        public void AddItem(Item item)
        {
            if (_hotbar.Count < maxHotbarSize)
                _hotbar.Add(item);
            else if (_inventory.Count < maxInventorySize)
                _inventory.Add(item);
            else
                throw new InventoryFullException(item);
        }

        public void SwitchActiveItem(int index)
        {
            if (index >= _hotbar.Count || index >= maxHotbarSize)
                return;
            
            activeItem = index;
        }

        public Item GetActiveItem()
        {
            return _hotbar[activeItem];
        }
    }
}