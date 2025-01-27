using UnityEngine;

[RequireComponent (typeof(Collider2D))]

public class BulletAttack1 : MonoBehaviour
{ 
    [SerializeField] private float speed=3f;
    [SerializeField] private int damage=1;
    [SerializeField] private float destroyTime =5f;
    private Transform player;


    private void Start()
    {
        player = FindAnyObjectByType<PlayerStats>().transform;
    } 
    private void Update()
    {
       
        Behaviour();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats player))
        {
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
       
    }

    private void Behaviour()
    {
        transform.position=Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
      
        destroyTime-= Time.deltaTime;
        if (destroyTime<=0) 
        {
            Destroy(this.gameObject);
        }
    }

  
}
