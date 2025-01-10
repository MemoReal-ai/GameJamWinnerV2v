using UnityEngine;

public class DEATHANIM : MonoBehaviour
{

    [SerializeField]
    private Enemy _enemy;

    [SerializeField] private Animator animator;
    
    
    private void OnEnable()
    {
        _enemy.OnDeath += DeathAnimation;
    }

    private void OnDisable()
    {
        _enemy.OnDeath -= DeathAnimation;
    }

    private void DeathAnimation()
    {
        animator.SetBool("DeathCrab",true);
    }
}
