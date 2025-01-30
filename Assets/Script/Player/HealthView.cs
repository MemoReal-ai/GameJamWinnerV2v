using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerStats playerHealth;
    [SerializeField] private  Image health;
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

       this.health.fillAmount = health;
    }

}
