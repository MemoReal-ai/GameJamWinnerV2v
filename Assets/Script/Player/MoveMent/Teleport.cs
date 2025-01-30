using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    [SerializeField] private Transform teleportPosition; // Позиция для телепортации

    public Transform GetTeleportPosition()
    {
        return teleportPosition;
    }
}