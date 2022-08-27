using TestRogueLike.Game.Items;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Characters.Players;
using TMPro;
using UnityEngine;

namespace TestRogueLike.UI
{
    public class AmmoCount : MonoBehaviour
    {
        private TextMeshProUGUI _label;

        private void Start()
        {
            _label = GetComponent<TextMeshProUGUI>();
            Item.OnItemUpdateCallback += UpdateText;
            Game.Characters.Players.Inventory.Instance.OnActiveItemChangedCallback += UpdateText;
        }

        private void UpdateText(Item item)
        {
            if (item is Gun gun)
                _label.SetText($"{gun.BulletsRemaining}/{gun.MagSize}");
            else
                _label.SetText("");
        }
    }
}
