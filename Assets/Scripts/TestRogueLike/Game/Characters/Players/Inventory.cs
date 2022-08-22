using System.Collections.Generic;
using TestRogueLike.Exceptions.Characters.Players;
using TestRogueLike.Game.Items;

namespace TestRogueLike.Game.Characters.Players
{
    public class Inventory
    {
        private const int MAX_HOTBAR_SIZE = 9;
        private const int MAX_INVENTORY_SIZE = 30;
        
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
            if (_hotbar.Count < MAX_HOTBAR_SIZE)
                _hotbar.Add(item);
            else if (_inventory.Count < MAX_INVENTORY_SIZE)
                _inventory.Add(item);
            else
                throw new InventoryFullException(item);
        }

        public Item SwitchActiveItem(int index)
        {
            if (index >= _hotbar.Count || index >= MAX_HOTBAR_SIZE)
                throw new IndexGreaterThanHotbarSize(index, MAX_HOTBAR_SIZE);
            
            activeItem = index;

            return GetActiveItem();
        }

        public Item GetActiveItem()
        {
            return _hotbar[activeItem];
        }
    }
}