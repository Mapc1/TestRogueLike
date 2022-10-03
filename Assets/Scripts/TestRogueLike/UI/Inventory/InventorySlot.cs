using TestRogueLike.Game.Items;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestRogueLike.UI.Inventory
{
    public class InventorySlot : Slot
    {
        public Button removeButton;

        public void OnRemoveButton()
        {
            Game.Characters.Players.Inventory.Instance.RemoveItem(Item);
        }

        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            
            if (eventData.pointerDrag == null)
                return;

            var other = eventData.pointerDrag.gameObject.GetComponent<Slot>();
            if (other.Item == null)
                return;
            
            var otherSlot = other.SlotNum;
            var inHotbar = other is HotbarSlot;

            Game.Characters.Players.Inventory.Instance.SwapItems(SlotNum, false, otherSlot, inHotbar);
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