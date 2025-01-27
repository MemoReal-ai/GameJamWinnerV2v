using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : BossAbstract
{
    [Header("Behaviour")]
    [SerializeField] private float cooldawnAttack=1f;
    [SerializeField] private TriggerController attack;
    [SerializeField] private Rigidbody2D bossRigidBody2D;
    [SerializeField] private List<Transform> pointToWalk = new List<Transform>();
    private float minDistanceToTaggingPoint = 0.1f;
    private Transform currentPoint;
    private bool canAttack=true;
    private bool isRunningCoolDawn = false;
    private float timeLastAttack;

    [Header("Attack2 Stats")]
    [SerializeField] private WaveAttack wavePrefab;

    [Header("Attack3 Stats")] 
    [SerializeField] private Bomb bombPrefab;


    public event Action<float> OnHealthChanged;

    private void Start()
    {
        maxHealth = currentHealth;

        target = FindAnyObjectByType<PlayerStats>().transform;
        attack = FindAnyObjectByType<TriggerController>();
        attack.FlikSword += BehaviourAttack;
       
        currentPoint=transform;
    }
    private void FixedUpdate()
    {
        Behaviour();
    }

    private void OnDisable()
    {
        attack.FlikSword -=BehaviourAttack;
    }
    private void Behaviour()
    {    
        bossRigidBody2D.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed*Time.deltaTime );

        if (Vector2.Distance(transform.position, currentPoint.position) <= minDistanceToTaggingPoint)
        {
            ChooseNewPoint();
        }
    }

    private void ChooseNewPoint()
    {
        var randomPoint = UnityEngine.Random.Range(0, pointToWalk.Count);
        currentPoint = pointToWalk[randomPoint];

    }
    protected override void Attack()
    {
       var bomb=Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }

    protected override void Attack2()

    {
        var waveProjectTile=Instantiate(wavePrefab,transform.position,Quaternion.identity);
    }

    protected override void Attack3()
    {
        var randomPoint = UnityEngine.Random.Range(0, pointToWalk.Count);
        transform.position=pointToWalk[randomPoint].position;
    }

    protected override void BehaviourAttack()
    {
        if (canAttack&&Time.time-timeLastAttack>=cooldawnAttack)
        {
            var currentAttack = UnityEngine.Random.Range(1, 4);


            switch (currentAttack)
            {
                case 1:
                    Attack();
                    break;
                case 2:
                    Attack2();
                    break;
                case 3:
                    Attack3();
                    break;

            }
        }
        timeLastAttack = Time.time;
        canAttack = false;
        if(!isRunningCoolDawn)
        StartCoroutine(CooldownAttack());
        
    }

    private IEnumerator CooldownAttack()
    {
        isRunningCoolDawn = true;
        yield return new WaitForSeconds(cooldawnAttack);
        canAttack = true;
        isRunningCoolDawn=false;
    }

    protected override void Die()
    {
        Destroy(this.gameObject);
    }

    protected override void TakeDamage()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            currentHealth -= playerStats.Damage;
            OnHealthChanged?.Invoke(GetHealthPercent());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageTrigger"))
        {
            TakeDamage();
        }

    }
}
