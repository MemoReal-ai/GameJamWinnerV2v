using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int damage = 1;

    private float taggingTodestroy = 0.1f;
    private Vector2 targetPosition;
    private Vector2 startPosition;
    private PlayerStats player;
    private void Start()
    {
        startPosition = transform.position;
        player = FindAnyObjectByType<PlayerStats>();
        targetPosition=player.transform.position;
    }

    private void FixedUpdate()
    {
        Behaviour();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats player))
        {
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }

    private void Behaviour()
    {
       transform.position=Vector2.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
      
        var distance = Vector2.Distance(transform.position, targetPosition);
        Debug.Log(distance);
        if (distance <taggingTodestroy)
        {
            Destroy(this.gameObject);
        }
    }

   
}

