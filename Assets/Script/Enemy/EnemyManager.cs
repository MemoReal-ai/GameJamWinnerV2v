using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField] private GameObject trigger; // Триггер, который включается, когда врагов больше нет

    private List<GameObject> activeEnemies = new List<GameObject>();

    public event Action OnAllEnemiesDestroyed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (trigger != null)
        {
            trigger.SetActive(false); // Отключаем триггер на старте
        }
    }

    public void RegisterEnemy(GameObject enemy)
    {
        activeEnemies.Add(enemy);
        Debug.Log("Enemy registered: " + enemy.name);
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
        Debug.Log("Enemy unregistered: " + enemy.name);

        if (activeEnemies.Count == 0)
        {
            Debug.Log("All enemies destroyed!");
            OnAllEnemiesDestroyed?.Invoke();

            if (trigger != null)
            {
                trigger.SetActive(true); // Включаем триггер
            }
        }
    }

    public int GetEnemyCount()
    {
        return activeEnemies.Count;
    }
}