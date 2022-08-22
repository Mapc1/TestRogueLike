using TestRogueLike.Game.Items.Weapons;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Items.Weapons.Guns.Bullets;
using UnityEngine;

namespace TestRogueLike.World.Items.Weapons.Guns
{
    public abstract class GunWorld : WeaponWorld
    {
        [SerializeField] protected AudioClip magEmptySound;
        [SerializeField] protected AudioClip reloadSound;

        protected BulletWorld bullet; 
        
        protected bool reloadButtonPressed;
        
        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                attackButtonPressed = true;
            else if (Input.GetButtonDown("Reload"))
                reloadButtonPressed = true;
        }

        private void FixedUpdate()
        {
            if (attackButtonPressed)
            {
                Attack();
                attackButtonPressed = false;
            }
            else if (reloadButtonPressed)
            {
                Reload();
                reloadButtonPressed = false;
            }
        }

        protected override void Attack()
        {
            if (Time.time < nextAttackTime) return;
         
            var gun = (Gun)_item;
            
            if (gun.bulletsRemaining > 0)
            {
                Debug.Log($"Bullet: {bullet} | transform: {_transform}");
                bullet.direction = _transform.forward;
                bullet.spawnPos = _transform.position;
                bullet.damage = gun.damage;
                var newBullet = Instantiate(bullet.gameObject, _transform.position, Quaternion.identity);
                newBullet.gameObject.SetActive(true);

                gun.fire();
                _audioSource.PlayOneShot(attackSound);
                //UpdateAmmoCount();
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
            //UpdateAmmoCount();
        }

        /*
        public void UpdateUI()
        {
            var gun = (Gun)_item;
            nameText.SetText(gun.name);
            UpdateAmmoCount();
        }

        private void UpdateAmmoCount()
        {
            var gun = (Gun)_item;
            ammoText.SetText($"{gun.bulletsRemaining}/{gun.magSize}");
        }
        */
    }
}