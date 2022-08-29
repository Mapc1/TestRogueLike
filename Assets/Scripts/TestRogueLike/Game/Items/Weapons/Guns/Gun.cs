using System;
using TestRogueLike.Game.Characters.Players;
using TestRogueLike.World.Items.Weapons.Guns.Bullets;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons.Guns
{
    public abstract class Gun : Weapon
    {
        public enum BulletType
        {
            Light,
            Medium,
            Heavy,
            Slug
        }

        private readonly BulletType _bullet;

        public readonly int MagSize;
        public int BulletsRemaining { get; private set; }

        protected Gun(string name, GameObject mesh, Sprite icon, int attackDamage, float attackCooldown, int magSize, BulletType bulletType) 
            : base(name, mesh, icon, attackDamage, attackCooldown)
        {
            _bullet = bulletType;
            MagSize = magSize;
            BulletsRemaining = magSize;
        }

        public void Fire()
        {
            BulletsRemaining--;
            OnItemUpdateCallback.Invoke(this);
        }

        public void Reload()
        {
            BulletsRemaining = MagSize;
            OnItemUpdateCallback.Invoke(this);
        }
        
        public BulletWorld GetBullet()
        {
            return _bullet switch
            {
                BulletType.Light => BulletAssets.instance.lightBullet,
                BulletType.Medium => BulletAssets.instance.mediumBullet,
                BulletType.Heavy => BulletAssets.instance.heavyBullet,
                BulletType.Slug => BulletAssets.instance.shotgunSlug,
                _ => null
            };
        }

        public override string GetStats()
        {
            var fireRate = Math.Round(1 / attackCooldown, 2);
            return $"Damage: {damage}\nFire Rate: {fireRate} bullets/s";
        }
    }
}