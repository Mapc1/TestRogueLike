using TestRogueLike.World.Characters.Players;
using UnityEngine;

namespace TestRogueLike.World.Items.Weapons.Guns.Bullets
{
    public abstract class BulletWorld : MonoBehaviour
    {
        public const int LAYER = 6;
        
        [SerializeField] protected float speed;
        [SerializeField] protected float maxTravel = 10.0f;

        private Rigidbody _rigidbody;
        private Transform _transform;
        
        public Vector3 direction;
        public Vector3 spawnPos;
        public int damage;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            gameObject.layer = LAYER;
            direction *= speed;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = direction;
            if (
                _transform.position.x < spawnPos.x - maxTravel ||
                _transform.position.x > spawnPos.x + maxTravel ||
                _transform.position.z < spawnPos.z - maxTravel ||
                _transform.position.z > spawnPos.z + maxTravel
            )
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer is PlayerWorld.LAYER or LAYER)
                return;
        
            Destroy(gameObject);
        }
    }
}
