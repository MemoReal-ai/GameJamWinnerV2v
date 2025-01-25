using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager Instance { get; private set; }
    private Vector2 lastTeleportPoint; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
    public void UpdateTeleportPoint(Vector2 newPoint)
    {
        lastTeleportPoint = newPoint;
    }
    
    public Vector2 GetTeleportPoint()
    {
        return lastTeleportPoint;
    }
}