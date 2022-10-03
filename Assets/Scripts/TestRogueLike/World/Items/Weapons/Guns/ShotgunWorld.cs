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
                    var yaw = Random.Range(-10, 10) * (Math.PI / 180);
                    var pitch = Random.Range(-10, 10) * (Math.PI / 180);
                    var forward = _transform.forward;
                    bullet.direction = new Vector3(forward.x + (float) Math.Sin(yaw), forward.y + (float) Math.Sin(pitch), forward.z).normalized;
                    bullet.spawnPos = _transform.position;
                    bullet.damage = shotty.damage;
                    var newBullet = Instantiate(bullet.gameObject, bullet.spawnPos, Quaternion.identity);
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