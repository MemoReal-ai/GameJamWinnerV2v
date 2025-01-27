using UnityEngine;

public class BulletAttack2 : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float distanceToDestroy = 10f; 

    private Vector2 startPosition;
    private Vector2 direction;
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
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
        transform.Translate(direction * speed * Time.deltaTime);

        var distance = Vector2.Distance(startPosition, transform.position);
     
        if (distance > distanceToDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction=direction.normalized;
    }
}
