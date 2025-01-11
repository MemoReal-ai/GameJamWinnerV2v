using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int health = 1;

    public event Action<GameObject> OnDeath;
    public event Action OnHealthChanged;

    protected PlayerStats player;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    protected virtual void Behaviour() { }

    protected virtual void Attack()
    {
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    public virtual void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        OnHealthChanged?.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        OnDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
