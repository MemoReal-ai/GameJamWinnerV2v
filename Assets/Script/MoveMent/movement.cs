using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 1f;
    private float directionX;
    private float directionY;
    private Rigidbody2D rb;

    [Header("Animator")]
    [SerializeField] private Animator animator;
    [SerializeField] private float constDirectionDiagonalWalk = 0.71f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        WalkAnimationController();
    }
    private void FixedUpdate()
    {
        HarvestInput();

    }


    private void HarvestInput()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical"); 
        var moveDirection=new Vector2(directionX,directionY).normalized;
        var prefersMove = rb.position+moveDirection* speed;
        rb.MovePosition(prefersMove);
        

    }

    private void WalkAnimationController()
    {
        if (directionX < 0)
        {
            SetAnimatorBools(walkLeft: true, walkRight: false, idle: false, walkDown: false, walkUp: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackLeft");
            }
        }
        else if (directionX > 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: true, idle: false, walkDown: false, walkUp: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackRight");
            }
        }
        else if (directionX == 0 && directionY == 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: false, idle: true, walkDown: false, walkUp: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackLeft");
            }
        }

        else if (directionY > 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: false, idle: false, walkUp: true, walkDown: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackUp");
            }
        }
        else if (directionY < 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: false, idle: false, walkUp: false, walkDown: true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackDown");
            }
        }
        
    }


    private void SetAnimatorBools(bool walkLeft, bool walkRight, bool idle, bool walkUp, bool walkDown)
    {
        animator.SetBool("walkLeft", walkLeft);
        animator.SetBool("walkRight", walkRight);
        animator.SetBool("idle", idle);
        animator.SetBool("walkUp", walkUp);
        animator.SetBool("walkDown", walkDown);
        
    }

    
        
    }
    
    
    
