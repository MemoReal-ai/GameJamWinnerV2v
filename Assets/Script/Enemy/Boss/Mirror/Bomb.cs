using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Header("Bomb Stats")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private Mine minePrefab;
    [SerializeField] private int mineCount;
    [SerializeField] private float timeToExplosion;
    [SerializeField] private float radius = 1f;

    private float distanceTaggigPlayer=0.1f;
    private bool isStartExplosion=false;
    private Vector2 targetPosition;
    private PlayerStats player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerStats>();
        targetPosition = player.transform.position;
    }

    private void FixedUpdate()
    {
        Behaviour();
    }

    private void Behaviour()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        var distance = Vector2.Distance(targetPosition, transform.position);

        if ( distance<=distanceTaggigPlayer&&isStartExplosion==false)
        {
            StartCoroutine(TimeToExplosion());
        }
    }

    private IEnumerator TimeToExplosion()
    {
        isStartExplosion = true;
        yield return new WaitForSeconds(timeToExplosion);
        for (int i = 0; i < mineCount; i++)
        {
            float angel=i*Mathf.PI*2/mineCount;
            Vector2 minePosition=new Vector2(
                transform.position.x+radius*Mathf.Cos(angel),
                transform.position.y+radius*Mathf.Sin(angel));

            Instantiate(minePrefab,minePosition,Quaternion.identity);

        }

        Destroy(this.gameObject);
    }
}

