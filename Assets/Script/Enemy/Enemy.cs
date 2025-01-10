
using System;
using System.Collections;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed=3;
    [SerializeField] protected int damage=1;
    [SerializeField] protected int health = 1;
    public event Action OnDeath;
    

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
            
            
            
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
        
        
        
    }
    
}
