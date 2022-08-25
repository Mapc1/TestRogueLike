using TestRogueLike.World.Characters.Players;
using TMPro;
using UnityEngine;

namespace TestRogueLike.UI
{
    public class ItemText : MonoBehaviour
    {
        private TextMeshProUGUI _label;
    
        [SerializeField] private PlayerWorld playerWorld;

        private void Awake() 
            => _label = GetComponent<TextMeshProUGUI>();

        private void LateUpdate()
            => _label.SetText(playerWorld.Player.Inventory.GetActiveItem().name);
    }
}
