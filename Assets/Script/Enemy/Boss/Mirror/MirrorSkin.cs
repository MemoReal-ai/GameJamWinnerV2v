using UnityEngine;

public class MirrorSkin : BossAbstract
{

    private void Update()
    {
        if (transform.childCount == 1)
        {
            Die();
        }
            
    }
    
    
    protected override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    protected override void BehaviourAttack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Attack2()
    {
        throw new System.NotImplementedException();
    }

    protected override void Attack3()
    {
        throw new System.NotImplementedException();
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