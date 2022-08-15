using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float Speed = 5.0f;

    [SerializeField] private Bullet bullet;
    
    private Rigidbody _rigidbody;
    
    private float _verticalInput;
    private float _horizontalInput;
    private bool _fireButtonPressed;
    
    private Vector3 _lookPos;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _fireButtonPressed = true;
        
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
        
        _lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_horizontalInput, 0, _verticalInput) * Speed;
        _rigidbody.transform.LookAt(new Vector3(_lookPos.x, _rigidbody.position.y, _lookPos.z));

        if (_fireButtonPressed)
        {
            _fireButtonPressed = false;
            bullet.direction = _rigidbody.transform.forward;
            bullet.spawnPos = _rigidbody.transform.position;
            var newBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            newBullet.gameObject.SetActive(true);
        }
    }
}
