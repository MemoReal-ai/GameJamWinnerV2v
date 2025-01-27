
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBoss : BossAbstract
{
    [Header("Behaviuor")]
    [SerializeField] private float startDelayAttack = 1f;
    [SerializeField] private float endDelayAttack = 1f;
    [SerializeField,Range(0,1000)] private float immortalTime = 60f;
   
    private float currentDelay;
    private float initialImmortalTime;
    private bool canAttack=true;
    private bool isImmortal=true;

    [Header("Attack1")]
    [SerializeField] private Laser prefabLaser;
    [SerializeField] private int countLaser = 1;
    [SerializeField] private float offsetRadius = 1f;



    [Header("Attack3")]
    [SerializeField] private Wall prefabWall;
    [SerializeField] private float timeToSpawn;

    [Header("Attack2")]
    [SerializeField] private CrabBehavior prefabCrab;
    [SerializeField] private int countCrabOnInstantiate=1;
    [SerializeField] private List<Transform> spawnPoints=new();
    public float TimeToSpawn=>timeToSpawn;

    private bool canSpawn=true;
    private event Action OnDead;
    private void OnValidate()
    {
        currentHealth = 1;
        timeToSpawn = immortalTime/2;
    }

    private void Start()
    {   initialImmortalTime=immortalTime;
        OnDead += TakeDamage;
    }
    private void Update()
    {
        if (canAttack)
            StartCoroutine(DelayAttack());

     
    }
    private void FixedUpdate()
    {
        Behaviour();
    }

    private void Behaviour()
    {
        immortalTime -= Time.deltaTime;

        if (immortalTime <= 0)
        {
            isImmortal = false;
            OnDead?.Invoke();
        }
    }

    private void OnDisable()
    {
        OnDead-=TakeDamage;
    }
    protected override void Attack()
    {
        var angleSteps=360/countLaser;

        for (int i = 0; i < countLaser; i++)
        {
            var angle = i * angleSteps;

            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 spawnPosition = transform.position + (Vector3)direction * offsetRadius;

            var angleRotation=Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

            var rotation = Quaternion.AngleAxis(angleRotation,Vector3.forward);
            var laser = Instantiate(prefabLaser,spawnPosition,rotation);
            laser.SetDirection(direction);
        }
      
    }

    protected override void Attack2()
    {
        for (int i = 0; i < countCrabOnInstantiate; i++)
        {
            var randompoint = UnityEngine.Random.Range(0, spawnPoints.Count);
            Instantiate(prefabCrab, spawnPoints[randompoint].position, Quaternion.identity);
        }
    }
    protected override void Attack3()
    {
 
            Instantiate(prefabWall, transform.position, Quaternion.identity);
            canSpawn=false;  
    }

   

    protected override void BehaviourAttack()
    {
        var currentAttack = UnityEngine.Random.Range(1, 3);

        switch (currentAttack)
        {
            case 1:
                Attack();
                break;
            case 2:
                Attack2();
                break;
        }

        if (immortalTime <= timeToSpawn && canSpawn == true)
            Attack3();
    }
    private IEnumerator DelayAttack()
    {
        canAttack = false;
         currentDelay = Mathf
            .Lerp(endDelayAttack,
            startDelayAttack,
           immortalTime/initialImmortalTime);
        yield return new WaitForSeconds(currentDelay);
        BehaviourAttack();
        canAttack = true;

    }

    protected override void Die()
    {
        Destroy(this.gameObject);
    }

  

    protected override void TakeDamage()
    {
        if (!isImmortal)
        {

            Die();
        }
    }
}
