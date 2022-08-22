using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Characters.Players;
using TMPro;
using UnityEngine;

public class AmmoCount : MonoBehaviour
{
    private TextMeshProUGUI _label;
    
    [SerializeField] private PlayerWorld playerWorld;

    private void Awake()
        => _label = GetComponent<TextMeshProUGUI>();

    private void LateUpdate()
    {
        var item = playerWorld._player._inventory.GetActiveItem();
        if (item is Gun gun)
            _label.SetText($"{gun.bulletsRemaining}/{gun.magSize}");
    }
}
