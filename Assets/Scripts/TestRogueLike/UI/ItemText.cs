using TestRogueLike.Game.Characters.Players;
using TestRogueLike.World.Characters.Players;
using TMPro;
using UnityEngine;

public class ItemText : MonoBehaviour
{
    private TextMeshProUGUI _label;
    
    [SerializeField] private PlayerWorld playerWorld;

    private void Awake() 
        => _label = GetComponent<TextMeshProUGUI>();

    private void LateUpdate()
        => _label.SetText(playerWorld._player._inventory.GetActiveItem().name);
}
