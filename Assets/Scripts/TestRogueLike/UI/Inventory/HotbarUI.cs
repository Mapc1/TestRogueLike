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

        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].SlotNum = i;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            if (_inventory._hotbar[i] != null)
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
