using System;
using TestRogueLike.Game.Characters.Players;
using TestRogueLike.UI;
using TestRogueLike.UI.Inventory;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private Transform itemsParent;
    [SerializeField] private GameObject inventoryUI;

    public bool IsInventoryOpen;
    
    private Inventory _inventory;
    private InventorySlot[] _slots;
    
    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.OnInventoryChangedCallback += UpdateUI;
        _slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        IsInventoryOpen = inventoryUI.activeSelf;
        Instance = this;

        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].SlotNum = i;
        }
    }

    public void LateUpdate()
    {
        if (Input.GetButtonDown("Inventory") && !PauseMenu.Instance.isOpen)
            IsInventoryOpen = !inventoryUI.activeSelf;
        else if (Input.GetButtonDown("Cancel") && IsInventoryOpen)
            IsInventoryOpen = false;
        
        inventoryUI.SetActive(IsInventoryOpen);
    }

    private void UpdateUI()
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            if (_inventory._inventory[i] != null)
                _slots[i].AddItem(_inventory._inventory[i]);
            else 
                _slots[i].ClearSlot();
        }
    }
}
