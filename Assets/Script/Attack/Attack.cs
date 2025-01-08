using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour
{
    public Collider2D triggerZone; 
    public float duration = 1.0f;
    [SerializeField] private float timeDelay = 0.5f;

    private Coroutine triggerCoroutine;


    public void ActivateTrigger()
    {
        
        
        
        if (triggerCoroutine != null)
        {
            StopCoroutine(triggerCoroutine); 
        }
        triggerCoroutine = StartCoroutine(EnableTriggerForDuration());
    }
    
    

    private IEnumerator EnableTriggerForDuration()
    {
        yield return new WaitForSeconds(timeDelay);
        
        
        triggerZone.enabled = true; 
        yield return new WaitForSeconds(duration); 
        triggerZone.enabled = false; 
    }

  
}