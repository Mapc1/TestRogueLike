using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    void Start()
    {
        
    }

    void Update()
    {
        var playerPosition = player.position;
        transform.position = new Vector3(playerPosition.x, 10, playerPosition.z-3);
        transform.LookAt(playerPosition);
    }

    private void FixedUpdate()
    {
    }
}
