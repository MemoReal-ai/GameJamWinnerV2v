using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health=4;
    [SerializeField] private int damage = 1;
   
    public event Action OnHealthChanged;

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnHealthChanged?.Invoke();
    } 
    
}
