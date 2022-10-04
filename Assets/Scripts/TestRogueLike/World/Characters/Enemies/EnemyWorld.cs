using TestRogueLike.Game.Characters.Enemies;
using TestRogueLike.Game.Items.Weapons;
using TestRogueLike.World.Items.Weapons.Guns.Bullets;
using UnityEngine;

namespace TestRogueLike.World.Characters.Enemies
{
    public class EnemyWorld : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private int maxHP;
        [SerializeField] private Weapon weapon;
    
        public Enemy _enemy;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _enemy = new Enemy(maxHP, weapon);
            
            _enemy.OnDeathCallback += OnDeath;
        }

        private void OnTriggerEnter(Collider other)
        {
            var bullet = other.gameObject.GetComponent<BulletWorld>();
            if (other.gameObject.layer != BulletWorld.LAYER || bullet == null)
                return;

            _enemy.TakeDmg(bullet.damage);
            _rigidbody.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}