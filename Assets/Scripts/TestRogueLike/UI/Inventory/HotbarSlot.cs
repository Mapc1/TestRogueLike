using TestRogueLike.Game.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TestRogueLike.UI.Inventory
{
    public class HotbarSlot : MonoBehaviour
    {
        public Image icon;

        private Item _item;

        public void AddItem(Item item)
        {
            _item = item;
            icon.sprite = _item.icon;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}