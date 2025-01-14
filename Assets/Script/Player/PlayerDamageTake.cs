using System.Collections;
using UnityEngine;

public class PlayerDamegeTakeView : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float timeToBlink=0.1f;
    [SerializeField] private int blincCount = 3;

    private void OnEnable()
    {
        player.OnHealthChanged += ViewDamage;
    }

    private void OnDisable()
    {
        player.OnHealthChanged -= ViewDamage;
    }

    private void ViewDamage(float health)
    {
        StartCoroutine(Delay());   
    }


    private IEnumerator Delay()
    {
        for (int i = 0; i < blincCount; i++) 
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(timeToBlink);

            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(timeToBlink);
        }
        
    }
}