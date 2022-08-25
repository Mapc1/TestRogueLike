using TestRogueLike.Game.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TestRogueLike.UI.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        public Image icon;
        public Button removeButton;
        
        private Item _item;

        public void OnRemoveButton()
        {
            Game.Characters.Players.Inventory.Instance.RemoveItemInventory(_item);
        }
        
        public void AddItem(Item item)
        {
            _item = item;
            icon.sprite = _item.icon;
            icon.enabled = true;
            removeButton.interactable = true;
        }

        public void ClearSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
            removeButton.interactable = false;
        }

        public void UseItem()
        {
            if (_item == null)
                return;
            
            _item.Use();
        }
    }
}