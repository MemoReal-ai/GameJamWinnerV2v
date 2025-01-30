using UnityEngine;

public class WallDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats player))
        {
            player.TakeDamage(damage);
        }

    }
}
