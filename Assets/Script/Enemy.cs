
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed=3;
    [SerializeField] private int damage=1;

    private float speedRotation=20;
    protected PlayerStats player;

    private void Start()
    {
      player=FindAnyObjectByType<PlayerStats>();    
    }
    protected virtual void Behaviour() 
    {

    }

    protected virtual void Attack()
    {
        player.TakeDamage(damage);
   
    }
}
