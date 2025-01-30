using UnityEngine;

public class SpiritBehaviour : Enemy
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Behaviour")]
    [SerializeField, Range(1, 10)] private float timeLife = 1f;
    private bool _isTagPlayer;

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
    }

    private void FixedUpdate()
    {
        if (_isTagPlayer)
       
            Behaviour();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerStats playerStats))
        {
            Attack();
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerStats playerStats))
        {
            animator.SetBool("TagPlayer", true);
            _isTagPlayer = true;
        }

    }  
        

    protected override void Behaviour()
    {
        timeLife -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        if(timeLife > 0f)
            return;
        Die();

    }


}

