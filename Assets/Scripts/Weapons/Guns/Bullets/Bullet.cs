using UnityEngine;

namespace Weapons.Guns.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float maxTravel = 10.0f;

        private Rigidbody _rigidbody;
        public Vector3 direction;
        public Vector3 spawnPos;
        public int damage;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            direction *= speed;
        }

        private void Update()
        {
        
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = direction;
            if (
                transform.position.x < spawnPos.x - maxTravel ||
                transform.position.x > spawnPos.x + maxTravel ||
                transform.position.z < spawnPos.z - maxTravel ||
                transform.position.z > spawnPos.z + maxTravel
            )
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 8)
                return;
        
            Destroy(gameObject);
        }
    }
}
