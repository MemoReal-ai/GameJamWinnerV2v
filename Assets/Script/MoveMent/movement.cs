using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private float directionX;
    private float directionY;
    private Rigidbody2D rb ;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HarvestInput();
    }

    

    private void HarvestInput()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        var prefersMove = new Vector2(transform.position.x + directionX, transform.position.y + directionY);
        rb.position = prefersMove;

    }
    
}
