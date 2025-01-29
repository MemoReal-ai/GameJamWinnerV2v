using System;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int currentHealth = 4;
    [SerializeField] private int damage = 1;
    

    private int maxHealth;
    public event Action<float> OnHealthChanged;
    public event Action OnDamageChanged;
    public event Action OnHealthIntChanged;
    public event Action OnDead;

    public int Damage => damage;

    public int CurrentHealth => currentHealth;

    private void Start()
    {
        maxHealth = currentHealth;
        OnHealthChanged?.Invoke(Clamper01Health());
        OnDamageChanged?.Invoke();
        OnHealthIntChanged?.Invoke();
    }

    public void RestoreHeal()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(Clamper01Health());
        OnHealthIntChanged?.Invoke();
    }


    public void ApllyHealth(int health)
    {
        maxHealth += health;
        currentHealth += health;
        OnHealthChanged?.Invoke(Clamper01Health());
        OnHealthIntChanged?.Invoke();
    }
    public void ApllyDamage(int damage)
    {
        this.damage += damage;
        OnDamageChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        OnHealthChanged?.Invoke(Clamper01Health());

        if (currentHealth == 0)
        {
            OnDead?.Invoke();
        }
    }

    private float Clamper01Health()
    {

        return (float)currentHealth / maxHealth;
    }
}