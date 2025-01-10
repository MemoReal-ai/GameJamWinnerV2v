using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private GameObject SecondenemyPrefab;
    [SerializeField] private int minEnemies = 1;     
    [SerializeField] private int maxEnemies = 5;     

    private BoxCollider2D triggerZone; 
    private bool hasSpawned = false; 

    private void Awake()
    {

        triggerZone = GetComponent<BoxCollider2D>();
        if (triggerZone == null || !triggerZone.isTrigger) ;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        int enemyCount = Random.Range(minEnemies, maxEnemies + 1); 
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 randomPosition = GetRandomPositionInTrigger();
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity); 
        }
    }

    private Vector2 GetRandomPositionInTrigger()
    {
        Vector2 randomOffset = new Vector2(
            Random.Range(-triggerZone.size.x / 2, triggerZone.size.x / 2),
            Random.Range(-triggerZone.size.y / 2, triggerZone.size.y / 2)
        );
        return (Vector2)transform.position + randomOffset;
    }

   
}
