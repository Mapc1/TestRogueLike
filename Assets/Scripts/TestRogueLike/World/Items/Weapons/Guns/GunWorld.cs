using System;
using TestRogueLike.Game.Items;
using TestRogueLike.Game.Items.Weapons;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Items.Weapons.Guns.Bullets;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace TestRogueLike.World.Items.Weapons.Guns
{
    public abstract class GunWorld : WeaponWorld
    {
        [SerializeField] protected AudioClip magEmptySound;
        [SerializeField] protected AudioClip reloadSound;
        [SerializeField] protected int forceMissRadius;

        protected BulletWorld Bullet; 
        
        protected bool ReloadButtonPressed;
        
        private void Update()
        {
            if (InventoryUI.Instance.IsInventoryOpen)
                return;
            
            if (Input.GetButtonDown("Fire1"))
                attackButtonPressed = true;
            else if (Input.GetButtonDown("Reload"))
                ReloadButtonPressed = true;
        }

        private void FixedUpdate()
        {
            if (attackButtonPressed)
            {
                Attack();
                attackButtonPressed = false;
            }
            else if (ReloadButtonPressed)
            {
                Reload();
                ReloadButtonPressed = false;
            }
        }

        public override void SetItem(Item item)
        {
            _item = item;
            var gun = (Gun)item;
            Bullet = gun.GetBullet();
        }

        protected override void Attack()
        {
            if (Time.time < nextAttackTime) return;
         
            var gun = (Gun)_item;
            
            if (gun.BulletsRemaining > 0)
            {
                var yaw = Random.Range(-forceMissRadius, forceMissRadius) * (Math.PI / 180);
                var pitch = Random.Range(-forceMissRadius, forceMissRadius) * (Math.PI / 180);

                var forward = _transform.forward;
                Bullet.direction = new Vector3(forward.x + (float) Math.Sin(yaw), forward.y + (float) Math.Sin(pitch), forward.z);
                Bullet.spawnPos = _transform.position;
                Bullet.damage = gun.damage;
                var newBullet = Instantiate(Bullet.gameObject, Bullet.spawnPos, Quaternion.identity);
                newBullet.gameObject.SetActive(true);

                gun.Fire();
                _audioSource.PlayOneShot(attackSound);
            }
            else
            {
                _audioSource.PlayOneShot(magEmptySound);
            }
            
            nextAttackTime = Time.time + gun.attackCooldown;
        }

        protected void Reload()
        {
            var gun = (Gun)_item;
            
            gun.Reload();
            _audioSource.PlayOneShot(reloadSound);
        }
    }
}