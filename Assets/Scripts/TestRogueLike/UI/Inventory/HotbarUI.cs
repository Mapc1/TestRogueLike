using TestRogueLike.Game.Characters.Players;
using TestRogueLike.UI.Inventory;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Transform itemsPanel;

    private Inventory _inventory;
    private HotbarSlot[] _slots;
    
    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.OnHotbarChangedCallback += UpdateUI;
        _slots = itemsPanel.GetComponentsInChildren<HotbarSlot>();
    }

    private void UpdateUI()
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            if (i < _inventory._hotbar.Count)
            {
                _slots[i].AddItem(_inventory._hotbar[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
