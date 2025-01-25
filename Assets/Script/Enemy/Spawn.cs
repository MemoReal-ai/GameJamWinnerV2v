using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyPrefabData
    {
        public GameObject enemyPrefab;
        public int enemyCount;
    }

    [SerializeField] private List<EnemyPrefabData> enemyPrefabsData;
    [SerializeField] private BoxCollider2D triggerCollider;
    [SerializeField] private List<GameObject> transitionObjects;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private bool hasSpawnedEnemies = false;

    void Start()
    {
        triggerCollider.enabled = true;
        triggerCollider.isTrigger = true;
        foreach (var transition in transitionObjects)
        {
            transition.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawnedEnemies)
        {
            hasSpawnedEnemies = true;
            SpawnEnemies();
            TeleportManager.Instance.UpdateTeleportPoint(transform.position);
        }
    }

    public void SpawnEnemies()
    {
        foreach (var data in enemyPrefabsData)
        {
            for (int i = 0; i < data.enemyCount; i++)
            {
                Vector2 randomPosition = new Vector2(
                    Random.Range(triggerCollider.bounds.min.x, triggerCollider.bounds.max.x),
                    Random.Range(triggerCollider.bounds.min.y, triggerCollider.bounds.max.y)
                );

                GameObject enemy = Instantiate(data.enemyPrefab, randomPosition, Quaternion.identity);
                spawnedEnemies.Add(enemy);
                enemy.GetComponent<Enemy>()._OnDeath += OnEnemyDeath;
            }
        }
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        spawnedEnemies.Remove(enemy);

        if (spawnedEnemies.Count == 0)
        {
            foreach (var transition in transitionObjects)
            {
                transition.SetActive(true);
            }
        }
    }
}
