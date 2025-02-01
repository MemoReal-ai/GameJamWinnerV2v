using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    [Header("Teleport Settings")]
    [SerializeField] private Transform player; 
    [SerializeField] private Vector3 targetPosition; 
    [SerializeField] private GameObject triggerObject; 

    private int remainingEnemies; 

    private void Start()
    {
        remainingEnemies = FindObjectsOfType<Enemy>().Length; 
        

    }

    public void OnEnemyDeath()
    {
        remainingEnemies--;
     

        if (remainingEnemies <= 0)
        {
           
            if (triggerObject != null)
            {
                triggerObject.SetActive(true); 
                
            }
          
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            
            if (player != null)
            {
                player.position = targetPosition; 
            }
        }
    }
}