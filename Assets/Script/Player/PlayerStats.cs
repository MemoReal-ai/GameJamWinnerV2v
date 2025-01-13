using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int currentHealth = 4;
    [SerializeField] private int damage = 1;

    private int maxHealth;
    public event Action OnHealthChanged;
    public event Action OnDead;
    public event Action DamageChanged;

    public int Damage => damage;

    private void Start()
    {
        maxHealth = currentHealth;

        
        OnHealthChanged?.Invoke();
    }

    public void RestoreHeal()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke();
    }

    public void ApllyHealth(int health)
    {
        this.maxHealth += health;
        this.currentHealth += health;
        OnHealthChanged?.Invoke();
    }
    public void ApllyDamage(int damage)
    {
        this.damage += damage;
        DamageChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
      
        currentHealth -= damage;
        OnHealthChanged?.Invoke();

        if (currentHealth == 0)
        {
            OnDead?.Invoke();
        }
    } 
    
}