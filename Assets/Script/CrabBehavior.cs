using UnityEngine;

public class CrabBehavior : Enemy
{
   
    private void Update()
    {
        Behaviour();
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
        base.Attack();
    }
}

