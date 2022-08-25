using System.Collections.Generic;
using TestRogueLike.Exceptions.Characters.Players;
using TestRogueLike.Game.Items;
using UnityEngine;

namespace TestRogueLike.Game.Characters.Players
{
    public class Inventory
    {
        public static Inventory Instance;

        public delegate void OnHotbarChanged();
        public OnHotbarChanged OnHotbarChangedCallback;
        
        public delegate void OnInventoryChanged();
        public OnInventoryChanged OnInventoryChangedCallback;

        public delegate void OnActiveItemChanged();
        public OnActiveItemChanged OnActiveItemChangedCallback;
        
        private const int MAX_HOTBAR_SIZE = 9;
        private const int MAX_INVENTORY_SIZE = 21;
        
        public List<Item> _hotbar { get; private set; }
        public List<Item> _inventory { get; private set; }

        private int activeItem;

        public Inventory(Item item, int hotbarSize = 10, int inventorySize = 10)
        {
            _hotbar = new List<Item> { item };
            _inventory = new List<Item>();

            activeItem = 0;

            Instance = this;
        }

        public void AddItem(Item item)
        {
            if (_hotbar.Count < MAX_HOTBAR_SIZE)
            {
                _hotbar.Add(item);
                OnHotbarChangedCallback.Invoke();
            } else if (_inventory.Count < MAX_INVENTORY_SIZE) 
            {
                _inventory.Add(item);
                OnInventoryChangedCallback.Invoke();
            } else
                throw new InventoryFullException(item);
        }

        public void RemoveItemInventory(Item item)
        {
            _inventory.Remove(item);
            OnInventoryChangedCallback.Invoke();
        }

        public void SwitchActiveItem(int index)
        {
            if (index >= _hotbar.Count || index >= MAX_HOTBAR_SIZE)
                throw new IndexGreaterThanHotbarSize(index, MAX_HOTBAR_SIZE);
            
            activeItem = index;
            OnActiveItemChangedCallback.Invoke();
            OnHotbarChangedCallback.Invoke();
        }

        public Item GetActiveItem()
        {
            return _hotbar[activeItem];
        }
        
        public void SwitchItemInventoryToHotbar(Item itemInventory, int index)
        {
            if (index >= MAX_HOTBAR_SIZE)
                throw new IndexGreaterThanHotbarSize(index, MAX_HOTBAR_SIZE);

            var tmp = _hotbar[index];
            _hotbar[index] = itemInventory;
            
            if (tmp != null)
            {
                var invIndex = _inventory.IndexOf(itemInventory);
                _inventory[invIndex] = tmp;
            }
            
            OnInventoryChangedCallback.Invoke();
            OnHotbarChangedCallback.Invoke();
            OnActiveItemChangedCallback.Invoke();
        }
    }
}