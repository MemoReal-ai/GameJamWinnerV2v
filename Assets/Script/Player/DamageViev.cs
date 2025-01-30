using TMPro;
using UnityEngine;


public class StatsView : MonoBehaviour
{

    [SerializeField] private PlayerStats player;
    [SerializeField] private TextMeshProUGUI textHealth;
    [SerializeField] private TextMeshProUGUI textDamage;
    private void OnEnable()
    {
        player.OnHealthIntChanged += HealthView;
        player.OnDamageChanged += DamageView;
    }

    private void OnDisable()
    {
        player.OnDamageChanged -= DamageView;
        player.OnHealthIntChanged -= HealthView;
        
    }


    private void DamageView() => textDamage.text=player.Damage.ToString();
    private void HealthView() => textHealth.text=player.CurrentHealth.ToString();
    
    

}

