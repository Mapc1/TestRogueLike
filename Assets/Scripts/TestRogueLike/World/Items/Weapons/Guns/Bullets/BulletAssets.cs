using System;
using TestRogueLike.Game.Items.Weapons.Guns;
using UnityEngine;

namespace TestRogueLike.World.Items.Weapons.Guns.Bullets
{
    public class BulletAssets : MonoBehaviour
    {
        public LightBulletWorld lightBullet;
        public MediumBulletWorld mediumBullet;
        public HeavyBulletWorld heavyBullet;
        public ShotgunSlugWorld shotgunSlug;

        public static BulletAssets instance { get; private set; }
        
        private void Awake()
        {
            instance = this;
        }

    }
}