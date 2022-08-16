using System;
using UnityEngine;

namespace Weapons.Guns
{
    public class Pistol : Gun
    {
        private void Start()
        {
            transform = GetComponent<Transform>();
            audioSource = GetComponent<AudioSource>();
            bulletsRemaining = magSize;
        }
    }
}