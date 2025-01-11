/*using System;
using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    [Header("Target Positions")]
    [SerializeField] private Vector2[] targetPositions;
    [SerializeField] private int selectedTargetIndex = 0;
    [SerializeField] private Spawn _spawn;

    public event Action LvlComplete; 
    
    
    
    private bool isActive = false;

    private void Update()
    {
        TheLvLComplete();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (isActive && other.CompareTag("Player"))
        {
            Debug.Log("1");
            MovePlayerToSelectedTarget(other.gameObject);
        }
    }
    
    private void TheLvLComplete()
    {
        if (_spawn.activeEnemies.Count == 0);
        {
            Activate();
        }
    }

    /*private void ToggleActive() => isActive = true;

    private void OnEnable()
    {
        
        LvlComplete += Activate;
    }

    private void OnDisable()
    {
        LvlComplete -= Activate;
    }
    #1#

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }

    private void MovePlayerToSelectedTarget(GameObject player)
    {
        
        if (targetPositions.Length > 0 && selectedTargetIndex >= 0 && selectedTargetIndex < targetPositions.Length)
        {
            player.transform.position = targetPositions[selectedTargetIndex];
            Deactivate();
        }
    }
}*/