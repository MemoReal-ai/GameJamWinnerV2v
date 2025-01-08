
using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed=3;
    [SerializeField] private int damage=1;
    [SerializeField] private int health = 1;

    private float speedRotation=20;
    protected PlayerStats player;
    public event Action OnHealthChanged; 

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

    protected virtual void LogicTakeDamage()
    {
        health -= player.Damage;
        
        OnHealthChanged?.Invoke();
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    
        
    
    
    
    
    
    
}
