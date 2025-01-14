using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerStats playerHealth;
    [SerializeField] private  Image healthBar;
    void Start()
    {
        playerHealth.OnHealthChanged += View;
    }
    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= View;
    }


    private void View(float health)
    {

        healthBar.fillAmount = health;
    }

}
