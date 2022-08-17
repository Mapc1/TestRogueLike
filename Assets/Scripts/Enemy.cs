using System;
using System.Collections;
using System.Collections.Generic;
using Characters.Enemy;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHP;
    
    private int _curHP;

    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _curHP = maxHP;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _curHP--;
            healthBar.UpdateHP(_curHP, maxHP);
            _rigidbody.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
            
            if (_curHP == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
