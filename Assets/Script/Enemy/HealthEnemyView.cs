using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyView : MonoBehaviour
{
    [SerializeField] private Enemy enemyHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private Transform enemyTransform;

    void Start()
    { 
        enemyHealth.OnHealthChanged += View;
 
    }

    private void LateUpdate()
    {
        transform.position = enemyTransform.position + new Vector3(0, 1, 0);
        transform.rotation = Quaternion.identity;
    }
    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= View;
    }


    private void View(float health)
    {

        healthBar.fillAmount = health;
    }

}
