using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health=4;
    [SerializeField] private int damage = 1;
   
    public event Action OnHealthChanged;
    public event Action OnDead;
    public int Damage => damage;

    public void TakeDamage(int damage)
    {
      
        health -= damage;
        OnHealthChanged?.Invoke();

        if (health == 0)
        {
            OnDead?.Invoke();
        }
    } 
    
}