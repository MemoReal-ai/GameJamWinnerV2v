using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    [Header("Teleport Settings")]
    [SerializeField] private Transform player; // Ссылка на игрока
    [SerializeField] private Vector3 targetPosition; // Координаты, куда нужно переместить игрока
    [SerializeField] private GameObject triggerObject; // Объект-триггер

    private int remainingEnemies; // Количество оставшихся врагов

    private void Start()
    {
        remainingEnemies = FindObjectsOfType<Enemy>().Length; // Подсчёт всех врагов на сцене
        Debug.Log("Initial enemies count: " + remainingEnemies);

    }

    public void OnEnemyDeath()
    {
        remainingEnemies--;
        Debug.Log($"Enemy died. Remaining enemies: {remainingEnemies}");

        if (remainingEnemies <= 0)
        {
            Debug.Log("All enemies defeated!");
            if (triggerObject != null)
            {
                triggerObject.SetActive(true); // Активируем триггер
                Debug.Log("Trigger activated.");
            }
            else
            {
                Debug.LogWarning("Trigger object is null.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, что триггер активировал игрок
        {
            Debug.Log("Player entered trigger. Teleporting...");
            if (player != null)
            {
                player.position = targetPosition; // Перемещаем игрока на заданные координаты
            }
        }
    }
}