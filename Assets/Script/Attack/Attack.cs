using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour
{
    public Collider2D triggerZone;
    public float duration = 1.0f;
    [SerializeField] private float timeDelay = 0.5f;

    private float timer = 0f; 
    private bool isTriggerActive = false;

    public void ActivateTrigger()
    {
        timer = timeDelay + duration;

        if (!isTriggerActive)
        {
            StartCoroutine(HandleTrigger());
        }
    }

    private IEnumerator HandleTrigger()
    {
        isTriggerActive = true;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        triggerZone.enabled = false; 
        isTriggerActive = false;
    }

    private void Update()
    {
        if (timer > duration)
        {
            triggerZone.enabled = false;
        }
        else if (timer > 0f)
        {
            triggerZone.enabled = true;
        }
    }
}
