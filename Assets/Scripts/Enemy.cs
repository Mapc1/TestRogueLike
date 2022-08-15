using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health = 5;

    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _health--;
            _rigidbody.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
            
            if (_health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
