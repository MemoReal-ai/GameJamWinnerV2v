using System;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class CrabBehavior : Enemy
{
    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Stats Behavior")]
    [SerializeField] private float distanceToAttack=1;
    [SerializeField] private float coldownAttack = 1;


    private float _timeLastAttack;


    private void FixedUpdate()
    {
        Behaviour();
        Attack();
    }

    protected override void Behaviour()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    protected override void Attack()
    {
        var distance=Vector2.Distance(transform.position, player.transform.position);

        _timeLastAttack += Time.deltaTime;
        if (distance < distanceToAttack&& _timeLastAttack>coldownAttack)
        {
            
            
            animator.SetTrigger("Attack");
            base.Attack();
            _timeLastAttack=0;
        }
    }

    protected override void LogicTakeDamage()
    {
        
        base.LogicTakeDamage();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DamageTrigger"))
        {
            LogicTakeDamage();
        }
    }

    private void OnEnable()
    {
        OnDeath += DeathAnimation;
    }

    private void OnDisable()
    {
        OnDeath -= DeathAnimation;
    }

    private void DeathAnimation()
    {
        animator.SetBool("death",true);
    }

   
}



/*using System.Collections;
using System.Xml.Schema;
using UnityEngine;

public class CrabBehavior : Enemy
{
    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Stats Behavior")]
    [SerializeField] private float distanceToAttack=1;
    [SerializeField] private float coldownAttack = 2;
    [SerializeField] private float delay = 1;
    
    
    private float _timeLastAttack;

    private void Start()
    {
        player=FindAnyObjectByType<PlayerStats>();
    }

    private void FixedUpdate()
    {
        Behaviour();
        Attack();
    }

    protected override void Behaviour()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    protected override void Attack()
    {
        var distance=Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceToAttack)
        {
            _timeLastAttack += Time.deltaTime;
        }
        else
        {
            _timeLastAttack = 0;
        }

        if (_timeLastAttack > coldownAttack)
        {
            animator.SetTrigger("Attack");
            
            StartCoroutine(DelayDamage());

           
            _timeLastAttack = 0;

        }
     
        
    }

    private IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds(delay);
        base.Attack();
    }
}

*/
