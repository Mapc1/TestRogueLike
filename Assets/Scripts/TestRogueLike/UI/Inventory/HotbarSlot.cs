using UnityEngine;
using UnityEngine.EventSystems;

namespace TestRogueLike.UI.Inventory
{
    public class HotbarSlot : Slot
    {
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

            Game.Characters.Players.Inventory.Instance.SwapItems(SlotNum, true, otherSlot, inHotbar);
        }
    }
}