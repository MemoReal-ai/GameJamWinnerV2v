using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform target; 
    [SerializeField]private float smoothing = 5f;
    [SerializeField]private Vector3 offset; 
    [SerializeField]private Vector2 minBounds; 
    [SerializeField]private Vector2 maxBounds; 

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minBounds.x, maxBounds.x);
        targetCamPos.y = Mathf.Clamp(targetCamPos.y, minBounds.y, maxBounds.y);
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
