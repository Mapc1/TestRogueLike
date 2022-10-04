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

        public delegate void OnActiveItemChanged(Item item);
        public OnActiveItemChanged OnActiveItemChangedCallback;
        
        public delegate void OnItemPickup(Item item);
        public OnItemPickup OnItemPickupCallback;

        private const int MAX_HOTBAR_SIZE = 9;
        private const int MAX_INVENTORY_SIZE = 21;

        public Item[] _hotbar { get; private set; }
        public Item[] _inventory { get; private set; }

        private int _activeItem;

        public Inventory(Item item)
        {
            _hotbar = new Item[MAX_HOTBAR_SIZE];
            _inventory = new Item[MAX_INVENTORY_SIZE];

            _hotbar[0] = item;
            _activeItem = 0;

            Instance = this;
        }

        public void AddItem(Item item)
        {
            var added = false;
            for (var i = 0; i < _hotbar.Length; i++)
            {
                if (_hotbar[i] == null)
                {
                    _hotbar[i] = item;
                    added = true;
                    break;
                }
            }
            if (!added) {
                for (var i = 0; i < _inventory.Length; i++)
                {
                    if (_inventory[i] == null)
                    {
                        _inventory[i] = item;
                        added = true;
                        break;
                    }
                }
            }

            if (!added)
                throw new InventoryFullException(item);
            
            OnInventoryChangedCallback.Invoke();
            OnHotbarChangedCallback.Invoke();
            OnActiveItemChangedCallback.Invoke(GetActiveItem());
            OnItemPickupCallback.Invoke(item);
        }

        public void RemoveItem(Item item)
        {
            var removed = false;
            for (var i = 0; i < _hotbar.Length; i++)
            {
                if (_hotbar[i] == item)
                {
                    _hotbar[i] = null;
                    removed = true;
                    break;
                }
            }
            if (removed)
                return;

            for (var i = 0; i < _inventory.Length; i++)
            {
                if (_inventory[i] == item)
                {
                    _inventory[i] = null;
                    break;
                }
            }
            
            OnInventoryChangedCallback.Invoke();
            OnHotbarChangedCallback.Invoke();
            OnActiveItemChangedCallback.Invoke(GetActiveItem());
        }

        public void SwitchActiveItem(int index)
        {
            if (index >= _hotbar.Length || index >= MAX_HOTBAR_SIZE)
                throw new IndexGreaterThanHotbarSize(index, MAX_HOTBAR_SIZE);

            _activeItem = index;
            OnActiveItemChangedCallback.Invoke(GetActiveItem());
        }

        public Item GetActiveItem()
        {
            return _hotbar[_activeItem];
        }

        public void SwapItems(int slotNum1, bool inHotbar1, int slotNum2, bool inHotbar2)
        {
            var item1 = inHotbar1 ? 
                _hotbar[slotNum1] : _inventory[slotNum1];
            var item2 = inHotbar2 ?
                _hotbar[slotNum2] : _inventory[slotNum2];

            if (inHotbar1)
                _hotbar[slotNum1] = item2;
            else
                _inventory[slotNum1] = item2;

            if (inHotbar2)
                _hotbar[slotNum2] = item1;
            else
                _inventory[slotNum2] = item1;
            
            OnInventoryChangedCallback.Invoke();
            OnHotbarChangedCallback.Invoke();
            OnActiveItemChangedCallback.Invoke(GetActiveItem());
        }
    }
}