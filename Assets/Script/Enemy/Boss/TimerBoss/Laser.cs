using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Laser Stats")]
    [SerializeField] private int damage = 1;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float timeToDestroy = 6f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int reflectTimes=3;

    private int reflectLeft;
    private Vector2 direction;

    private void Start()
    {
        reflectLeft = reflectTimes;
        
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
       else if ((1 << collision.gameObject.layer & wallLayer) != 0)
        {

           
            if (reflectLeft <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Reflect(collision.contacts[0].normal);
                reflectLeft--;
            }    
        }
      
    }


    private void Reflect(Vector2 normal)
    {
        direction = Vector2.Reflect(direction, normal);
        float angle= Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation=Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Behaviour()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        timeToDestroy-= Time.deltaTime;
        
        if (timeToDestroy <= 0)
            Destroy(gameObject);
    }
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;

    }
}
