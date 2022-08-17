using System;
using UnityEngine;

namespace Weapons.Guns
{
    public class AssaultRifle : Gun
    {
        public const string GunName = "Assault Rifle";
        
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