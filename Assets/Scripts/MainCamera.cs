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
        var position = player.position;
        transform.position = new Vector3(position.x, 10, position.z);
    }

    private void FixedUpdate()
    {
    }
}
