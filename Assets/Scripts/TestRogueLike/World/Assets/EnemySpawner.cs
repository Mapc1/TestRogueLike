using System;
using TestRogueLike.World.Characters.Enemies;
using UnityEngine;

namespace TestRogueLike.World.Assets
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private float cooldown;
        
        private EnemyWorld _enemySpawned;
        private float _nextSpawnTime = 0f;
        private bool playDeath;

        private void Start()
        {
            SpawnEnemy();
        }

        private void Update()
        {
            if(Time.time < _nextSpawnTime || !playDeath)
                return;
            
            SpawnEnemy();
        }

        private void SetDeath()
        {
            playDeath = true;
            _nextSpawnTime = Time.time + cooldown;
        }

        private void SpawnEnemy()
        {
            var newEnemy = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
            _enemySpawned = newEnemy.GetComponent<EnemyWorld>();
            _enemySpawned._enemy.OnDeathCallback += SetDeath;
            newEnemy.SetActive(true);
            playDeath = false;
        }
    }
}