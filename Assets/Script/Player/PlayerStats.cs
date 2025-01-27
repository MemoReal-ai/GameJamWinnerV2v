using System;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int currentHealth = 4;
    [SerializeField] private int damage = 1;

    private int maxHealth;
    public event Action<float> OnHealthChanged;
    public event Action OnDead;

    public int Damage => damage;

    private void Start()
    {
        maxHealth = currentHealth;
        OnHealthChanged?.Invoke(Clamper01Health());
    }

    public void RestoreHeal()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(Clamper01Health());
    }


    public void ApllyHealth(int health)
    {
        maxHealth += health;
        currentHealth += health;
        OnHealthChanged?.Invoke(Clamper01Health());
    }
    public void ApllyDamage(int damage)
    {
        this.damage += damage;
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