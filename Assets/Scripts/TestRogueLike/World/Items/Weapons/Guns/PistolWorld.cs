using System;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Items.Weapons.Guns.Bullets;
using UnityEngine;

namespace TestRogueLike.World.Items.Weapons.Guns
{
    public class PistolWorld : GunWorld
    {
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _audioSource = GetComponent<AudioSource>();
            _item = new Pistol();
            var gun = (Gun)_item;
            
            bullet = gun.GetBullet();
        }
    }
}