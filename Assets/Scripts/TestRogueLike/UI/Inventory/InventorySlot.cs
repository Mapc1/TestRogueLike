using TestRogueLike.Game.Items;
using UnityEngine.UI;

namespace TestRogueLike.UI.Inventory
{
    public class InventorySlot : Slot
    {
        public Button removeButton;

        public void OnRemoveButton()
        {
            Game.Characters.Players.Inventory.Instance.RemoveItemInventory(Item);
        }

        public override void AddItem(Item item)
        {
            base.AddItem(item);
            removeButton.interactable = true;
        }

        public override void ClearSlot()
        {
            base.ClearSlot();
            removeButton.interactable = false;
        }
    }
}