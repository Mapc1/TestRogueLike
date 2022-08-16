using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Weapons;

public class Player : MonoBehaviour
{
    private const float Speed = 5.0f;
    
    [SerializeField] private Weapon startingWeapon;
    [SerializeField] private Weapon startingWeapon2;
    
    private Rigidbody _rigidbody;
    
    private float _verticalInput;
    private float _horizontalInput;
    private bool _equipWeapon1Pressed;
    private bool _equipWeapon2Pressed;
    
    private Vector3 _lookPos;

    private Weapon[] _weaponSlots = new Weapon[5];
    private int _equippedWeapon;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _weaponSlots[0] = startingWeapon;
        _weaponSlots[1] = startingWeapon2;
        _equippedWeapon = 0;
    }

    void Update()
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
        _weaponSlots[_equippedWeapon].gameObject.SetActive(false);
        _weaponSlots[index].gameObject.SetActive(true);
        _equippedWeapon = index;
    }
}
