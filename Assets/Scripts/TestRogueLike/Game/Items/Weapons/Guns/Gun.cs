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

        public readonly BulletType bullet;

        public readonly int magSize;
        public int bulletsRemaining { get; private set; }

        protected Gun(string name, GameObject mesh, int attackDamage, float attackCooldown, int magSize, BulletType bulletType) 
            : base(name, mesh, attackDamage, attackCooldown)
        {
            bullet = bulletType;
            this.magSize = magSize;
            bulletsRemaining = magSize;
        }

        public int fire()
        {
            return --bulletsRemaining;
        }

        public void Reload()
        {
            bulletsRemaining = magSize;
        }
        
        public BulletWorld GetBullet()
        {
            return bullet switch
            {
                BulletType.Light => BulletAssets.instance.lightBullet,
                BulletType.Medium => BulletAssets.instance.mediumBullet,
                BulletType.Heavy => BulletAssets.instance.heavyBullet,
                BulletType.Slug => BulletAssets.instance.shotgunSlug,
                _ => null
            };
        }
    }
}