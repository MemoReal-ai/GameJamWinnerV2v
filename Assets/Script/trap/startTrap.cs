using System;
using UnityEngine;


public class startTrap : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
            if (animator != null)
            {
                animator.SetTrigger("TriggerTrap");
            }
    }
}
