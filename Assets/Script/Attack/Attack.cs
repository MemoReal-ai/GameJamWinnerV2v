using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour
{
    public Collider2D triggerZone; 
    public float duration = 1.0f; 

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
        triggerZone.enabled = true; 
        yield return new WaitForSeconds(duration); 
        triggerZone.enabled = false; 
    }
}