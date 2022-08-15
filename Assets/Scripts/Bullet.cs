using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public const float Speed = 10.0f;
    private const float MaxTravel = 10.0f;

    private Rigidbody _rigidbody;
    public Vector3 direction;
    public Vector3 spawnPos;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        direction *= Speed;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = direction;
        if (
            transform.position.x < spawnPos.x - MaxTravel ||
            transform.position.x > spawnPos.x + MaxTravel ||
            transform.position.z < spawnPos.z - MaxTravel ||
            transform.position.z > spawnPos.z + MaxTravel
            )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
            return;
        
        Destroy(gameObject);
    }
}
