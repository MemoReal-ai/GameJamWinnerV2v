using System;
using UnityEngine;

public class CrabBehavior : Enemy
{
    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("Stats Behavior")]
    [SerializeField] private float distanceToAttack = 1f;
    [SerializeField] private float coldownAttack = 1f;

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
        var distance = Vector2.Distance(transform.position, player.transform.position);
        _timeLastAttack += Time.deltaTime;

        if (distance < distanceToAttack && _timeLastAttack > coldownAttack)
        {
            animator.SetTrigger("Attack");
            base.Attack();
            _timeLastAttack = 0;
        }
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("DamageTrigger"))
        {
            TakeDamage(1);
        }
    }

    /*private void OnEnable()
    {
        OnDeath += DeathAnimation;
    }

    private void OnDisable()
    {
        OnDeath -= DeathAnimation;
    }

    private void DeathAnimation(GameObject enemy)
    {
        animator.SetBool("death", true);
        // Optionally add a delay to destroy the enemy after animation finishes
        Destroy(gameObject, 1f); // Adjust the delay based on animation duration
    }*/
}


/*
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
*/

