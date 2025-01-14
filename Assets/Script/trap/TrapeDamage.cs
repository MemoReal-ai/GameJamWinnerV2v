using System.Collections;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1; // Урон от ловушки
    [SerializeField] private float damageInterval = 1f; // Интервал между нанесением урона

    private bool canDealDamage = true; // Флаг для контроля интервала урона

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerStats>(out PlayerStats player))
        {
            if (canDealDamage)
            {
                StartCoroutine(DealDamageWithDelay(player));
            }
        }
    }

    private IEnumerator DealDamageWithDelay(PlayerStats player)
    {
        canDealDamage = false; // Блокируем повторный урон
        player.TakeDamage(damageAmount); // Наносим урон
        yield return new WaitForSeconds(damageInterval); // Ждем интервал
        canDealDamage = true; // Разрешаем наносить урон снова
    }
}