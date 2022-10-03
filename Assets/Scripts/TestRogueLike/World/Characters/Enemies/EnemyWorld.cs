using TestRogueLike.World.Items.Weapons.Guns.Bullets;
using UnityEngine;

namespace TestRogueLike.World.Characters.Enemies
{
    public class EnemyWorld : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private int maxHP;
    
        private int _curHP;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _curHP = maxHP;
        }

        private void OnTriggerEnter(Collider other)
        {
            var bullet = other.gameObject.GetComponent<BulletWorld>();
            if (other.gameObject.layer != BulletWorld.LAYER || bullet == null)
                return;

            _curHP -= bullet.damage;
            healthBar.UpdateHP(_curHP, maxHP);
            _rigidbody.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
            
            if (_curHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}