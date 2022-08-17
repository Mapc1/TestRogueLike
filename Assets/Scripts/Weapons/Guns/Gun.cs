using UnityEngine;

namespace Weapons.Guns
{
    public abstract class Gun : Weapon
    {
        [SerializeField] protected Bullet bullet;
        [SerializeField] protected AudioClip magEmptySound;
        [SerializeField] protected AudioClip reloadSound;
        [SerializeField] protected int magSize;

        protected int bulletsRemaining;

        public override void init()
        {
            transform = GetComponent<Transform>();
            audioSource = GetComponent<AudioSource>();
            bulletsRemaining = magSize;
        }

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
            
            if (bulletsRemaining > 0)
            {
                bullet.direction = transform.forward;
                bullet.spawnPos = transform.position;
                var newBullet = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
                newBullet.gameObject.SetActive(true);

                bulletsRemaining--;
                audioSource.PlayOneShot(attackSound);
                UpdateAmmoCount();
            }
            else
            {
                audioSource.PlayOneShot(magEmptySound);
            }
            
            nextAttackTime = Time.time + attackCooldown;
        }

        protected void Reload()
        {
            bulletsRemaining = magSize;
            audioSource.PlayOneShot(reloadSound);
            UpdateAmmoCount();
        }

        public override void UpdateUI()
        {
            nameText.SetText(weaponName);
            UpdateAmmoCount();
        }

        private void UpdateAmmoCount()
        {
                ammoText.SetText($"{bulletsRemaining}/{magSize}");
        }
    }
}