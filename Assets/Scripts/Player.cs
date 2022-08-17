using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Weapons;

public class Player : MonoBehaviour
{
    private const float Speed = 5.0f;
    
    [SerializeField] private Weapon startingWeapon;
    [SerializeField] private Weapon startingWeapon2;
    [SerializeField] private TextMeshProUGUI gunNameText;
    
    private Rigidbody _rigidbody;
    
    private float _verticalInput;
    private float _horizontalInput;
    private bool _equipWeapon1Pressed;
    private bool _equipWeapon2Pressed;
    
    private Vector3 _lookPos;

    public Weapon[] weaponSlots = new Weapon[5];
    public int equippedWeapon;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        weaponSlots[0] = startingWeapon;
        weaponSlots[1] = startingWeapon2;
        equippedWeapon = 0;
        
        // Initialize all weapons including disabled weapons
        // Workaround to the fact that Start() only gets run on active Game Objects
        foreach (var weapon in weaponSlots)
        {
            if (weapon is null) 
                continue;
            
            weapon.init();
            weapon.gameObject.SetActive(false);
        }
        
        weaponSlots[equippedWeapon].gameObject.SetActive(true);
        weaponSlots[equippedWeapon].UpdateUI();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Equip Weapon 1"))
            _equipWeapon1Pressed = true;
        else if (Input.GetButtonDown("Equip Weapon 2"))
            _equipWeapon2Pressed = true;
        
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        _lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_horizontalInput, 0, _verticalInput) * Speed;
        _rigidbody.transform.LookAt(new Vector3(_lookPos.x, _rigidbody.position.y, _lookPos.z));

        if (_equipWeapon1Pressed)
        {
            SwitchEquippedWeapon(0);
            _equipWeapon1Pressed = false;
        }
        else if (_equipWeapon2Pressed)
        {
            SwitchEquippedWeapon(1);
            _equipWeapon2Pressed = false;
        }
    }

    private void SwitchEquippedWeapon(int index)
    {
        weaponSlots[equippedWeapon].gameObject.SetActive(false);
        weaponSlots[index].gameObject.SetActive(true);
        equippedWeapon = index;
        weaponSlots[equippedWeapon].UpdateUI();
    }
}
