using System;
using UnityEngine;

public abstract class BossAbstract : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int currentHealth= 10;
    [SerializeField] protected float speed=1;
    

    protected int maxHealth;

    [Header("Target")]
    [SerializeField] protected PlayerStats playerStats;

    protected Transform target;
    public event Action OnDeath;

   
    protected abstract void  TakeDamage();
    protected abstract void BehaviourAttack();
    protected abstract void Attack();
    protected abstract void Attack2();
    protected abstract void Attack3();

    protected abstract void Die();
    protected virtual float GetHealthPercent()
    {
        return (float)currentHealth/maxHealth;
    }

    protected virtual void DieBoss()
    {
        OnDeath?.Invoke();
    }

}
