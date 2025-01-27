using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Stats Enemy")]
    [SerializeField] protected float speed = 3;
    [SerializeField] private int damage = 1;
    [SerializeField] private int currentHealth = 1;
    private int maxHealth;

    [Header("Resources")]
    [SerializeField, Range(0f, 1f)] protected float chanceAddCoin = 0.5f;
    [SerializeField] protected int rewardCoin = 1;
    [SerializeField] private UnityEngine.GameObject prefabCoin;


    protected PlayerStats player;
    public event Action<float> OnHealthChanged;
    public event Action OnDeath;
    public event Action<UnityEngine.GameObject> _OnDeath;


    public float ChanceAddCoin => chanceAddCoin;
    public int RewardCoin => rewardCoin;

    private void Start()
    {
        maxHealth = currentHealth;
        player = FindAnyObjectByType<PlayerStats>();
    }
    protected virtual void Behaviour()
    {

    }

    protected virtual void Attack() => player.TakeDamage(damage);


    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        OnHealthChanged?.Invoke(Clamper01Health());

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnEnable()
    {
        OnDeath += InstantiateCoin;
    }

    private void OnDisable()
    {
        OnDeath -= InstantiateCoin;
    }

    protected virtual void InstantiateCoin()
    {
        var random = UnityEngine.Random.value;

        if (random > chanceAddCoin)
        {
            return;
        }

        UnityEngine.GameObject coin = Instantiate(prefabCoin, transform.position, Quaternion.identity);

        if (coin.TryGetComponent<Coin>(out Coin coinComponent))
        {
            coinComponent.SetCoinValue(rewardCoin);
        }


    }
    protected virtual void Die()
    {
        OnDeath?.Invoke();
        _OnDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }

    private float Clamper01Health()
    {

        return (float)currentHealth / maxHealth;
    }
}