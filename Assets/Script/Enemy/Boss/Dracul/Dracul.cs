using System;
using System.Collections;
using UnityEngine;

public class Dracul : BossAbstract
{
    [Header("Attack1 Stats")]
    [SerializeField] private BulletAttack1 prefab;
    [SerializeField] private int countBullet;
    private Vector3 offset = Vector3.one;

    [Header("Attack2 Stats")]
    [SerializeField] private BulletAttack2 prefab2;
    [SerializeField] private int countBullet2;
    [SerializeField] private float ofssetRadius = 2f;



    [Header("Attack3 Stats")]
    [SerializeField] private startTrap prefabTrap;
    [SerializeField] private float radiusInstantiateTrap = 5f;


    [Header("Behaviour")]
    [SerializeField] private float timeDelayTeleport=1f;
    [SerializeField] private float radiusTeleport = 3f;
    [SerializeField] private LayerMask wall;
    [SerializeField] protected float delayAttack = 1f;

    private float radiusTaggingWall = 0.5f;
    private float startTeleportTime = 0f;
    

    private bool canAttack = true;

    public event Action<float> OnHealthChanged;
  

    private void Start()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();
     maxHealth=currentHealth;
     target = FindAnyObjectByType<PlayerStats>().transform;  
    }

    private void Update()
    {
        if (canAttack)
        StartCoroutine(DelayAttack());
        
       
    }

    private void FixedUpdate()
    {
        Teleport();
    }

    private void Teleport()
    {
        startTeleportTime += Time.deltaTime;
        if (startTeleportTime > timeDelayTeleport)
        {
            startTeleportTime = 0f;
       
            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Vector3 teleportPosition = target.position + (Vector3)randomDirection * radiusTeleport;

      
            if (!Physics2D.OverlapCircle(teleportPosition, radiusTaggingWall, wall))
            {

                transform.position = teleportPosition;
            }
        }
    }

    protected override void BehaviourAttack()
    {
        var currentAttack = UnityEngine.Random.Range(1, 4);
       
        switch(currentAttack)
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

    protected override void TakeDamage()
    {

       
        currentHealth -= playerStats.Damage;
        OnHealthChanged?.Invoke(GetHealthPercent());

        if (currentHealth < 0)
            Die();


    }
    
    protected override void Attack()
    {
        for (int i = 0; i < countBullet; i++)
        {
           Instantiate(prefab, transform.position + offset, Quaternion.identity);
            offset+=Vector3.one;
        }

        offset=Vector3.one;
    }
    protected override void Attack2()
    {
        var angleSteps = 360 / countBullet2;


        for(int i = 0;i < countBullet2; i++)
        {
            var angle= i*angleSteps;
           
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 spawnPosition = transform.position + (Vector3)direction * ofssetRadius;
            BulletAttack2 bullet2 = Instantiate(prefab2,spawnPosition,Quaternion.identity);
            bullet2.SetDirection(direction);
        }
    }

    protected override void Attack3()
    {
      Instantiate(prefabTrap, transform.position*radiusInstantiateTrap, Quaternion.identity);

    }

    private IEnumerator DelayAttack()
    {
        canAttack=false;
        yield return new WaitForSeconds(delayAttack);
        BehaviourAttack();
        canAttack=true;

    }
    protected override  float GetHealthPercent()
    {
       return  base.GetHealthPercent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DamageTrigger"))
        {
            TakeDamage();
        }
    }


    protected override void Die()
    {
        base.DieBoss();
        Destroy(this.gameObject);
        
    }

    protected override void DieBoss()
    {
        base.DieBoss();
    }
} 
 