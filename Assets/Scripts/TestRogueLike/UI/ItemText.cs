using TestRogueLike.Game.Items;
using TestRogueLike.World.Characters.Players;
using TMPro;
using UnityEngine;

namespace TestRogueLike.UI
{
    public class ItemText : MonoBehaviour
    {
        private TextMeshProUGUI _label;

        private void Start()
        {
            _label = GetComponent<TextMeshProUGUI>();
            Game.Characters.Players.Inventory.Instance.OnActiveItemChangedCallback += UpdateText;
        }

        private void UpdateText(Item item)
        {
            _label.SetText
            (
                item != null ? 
                    item.name : "Empty"
            );
        }
    }
}
