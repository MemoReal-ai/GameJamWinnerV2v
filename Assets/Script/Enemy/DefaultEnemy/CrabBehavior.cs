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

        if (distance > distanceToAttack)
        {
       
            _timeLastAttack = 0;
        }


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
            TakeDamage(player.Damage);
        }
    }

}
