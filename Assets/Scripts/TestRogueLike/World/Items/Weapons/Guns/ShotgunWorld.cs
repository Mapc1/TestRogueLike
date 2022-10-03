using System;
using TestRogueLike.Game.Items.Weapons.Guns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestRogueLike.World.Items.Weapons.Guns
{
    public class ShotgunWorld : GunWorld
    {
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _audioSource = GetComponent<AudioSource>();
        }

        protected override void Attack()
        {
            if (Time.time < nextAttackTime)
                return;

            var shotty = (Shotgun)_item;

            if (shotty.BulletsRemaining > 0)
            {
                for (var i = 0; i < 5; i++)
                {
                    var yaw = Random.Range(-forceMissRadius, forceMissRadius) * (Math.PI / 180);
                    var pitch = Random.Range(-forceMissRadius, forceMissRadius) * (Math.PI / 180);
                    var forward = _transform.forward;
                    Bullet.direction = new Vector3(forward.x + (float) Math.Sin(yaw), forward.y + (float) Math.Sin(pitch), forward.z).normalized;
                    Bullet.spawnPos = _transform.position;
                    Bullet.damage = shotty.damage;
                    var newBullet = Instantiate(Bullet.gameObject, Bullet.spawnPos, Quaternion.identity);
                    newBullet.gameObject.SetActive(true);
                }
                
                shotty.Fire();
                _audioSource.PlayOneShot(attackSound);
            }
            else
            {
                _audioSource.PlayOneShot(magEmptySound);
            }

            nextAttackTime = Time.time + shotty.attackCooldown;
        }
    }
}