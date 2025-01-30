/*using System;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SubscribeToDeathEvent(Enemy enemy)
    {
        enemy.OnDeath += DeathAnimation;
    }

    public void UnsubscribeFromDeathEvent(Enemy enemy)
    {
        enemy.OnDeath -= DeathAnimation;
    }

    private void DeathAnimation(GameObject enemy)
    {
        animator.SetBool("death", true);
    }
}*/