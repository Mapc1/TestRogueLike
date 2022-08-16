using System;
using UnityEngine;

namespace Weapons.Guns
{
    public class AssaultRifle : Gun
    {
        private void Start()
        {
            transform = GetComponent<Transform>();
            audioSource = GetComponent<AudioSource>();
            bulletsRemaining = magSize;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                attackButtonPressed = true;
            else if (Input.GetButtonUp("Fire1"))
                attackButtonPressed = false;
            else if (Input.GetButtonDown("Reload"))
                reloadButtonPressed = true;
        }
        
        private void FixedUpdate()
        {
            if (attackButtonPressed)
                Attack();
            else if (reloadButtonPressed)
            {
                Reload();
                reloadButtonPressed = false;
            }
        }
    }
}