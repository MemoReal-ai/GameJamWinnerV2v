using System;
using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float dashDistance = 2f;
    [SerializeField] private float dashCooldawn = 1f;
    [SerializeField] private float chargeSpeed = 0.2f;
    private float directionX;
    private float directionY;
    private Rigidbody2D rb;
    private float timeLastDash;

    [Header("Animator")]
    [SerializeField] private Animator animator;
    [SerializeField] private float constDirectionDiagonalWalk = 0.71f;
    public TriggerController _triggerController;


    private void Start()
    {
        timeLastDash = -dashCooldawn;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Update()
    { 
        WalkAnimationController();
        Charge();
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
    private void Charge()
    {
        var difDash = Time.time - timeLastDash;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (difDash >= dashCooldawn)
            {
                var dashDirection = new Vector2(directionX, directionY).normalized;
                if (dashDirection != Vector2.zero)
                {
                    StartCoroutine(DashTime(dashDirection * dashDistance));
                    timeLastDash = Time.time;

                }

            }
        }

    }

    private IEnumerator DashTime(Vector2 dashDirection)
    {
        float dashDuration = chargeSpeed;
        float dashDistance = this.dashDistance;


        Vector3 startPosition = transform.position;
        Vector3 dashTarget = startPosition + (Vector3)dashDirection * dashDistance;

        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            float t = elapsedTime / dashDuration;
            transform.position = Vector3.Lerp(startPosition, dashTarget, t);
            elapsedTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        transform.position = dashTarget;


    }

    private void WalkAnimationController()
    {
        if (directionX < 0)
        {
            SetAnimatorBools(walkLeft: true, walkRight: false, idle: false, walkDown: false, walkUp: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackLeft");
                if (_triggerController != null)
                {
                    _triggerController.ActivateTrigger();
                }
            }
        }
        else if (directionX > 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: true, idle: false, walkDown: false, walkUp: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackRight");
                if (_triggerController != null)
                {
                    _triggerController.ActivateTrigger();
                }
            }
        }
        else if (directionX == 0 && directionY == 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: false, idle: true, walkDown: false, walkUp: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackLeft");
                if (_triggerController != null)
                {
                    _triggerController.ActivateTrigger();
                }
            }
        }

        else if (directionY > 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: false, idle: false, walkUp: true, walkDown: false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackUp");
                if (_triggerController != null)
                {
                    _triggerController.ActivateTrigger();
                }
            }
        }
        else if (directionY < 0)
        {
            SetAnimatorBools(walkLeft: false, walkRight: false, idle: false, walkUp: false, walkDown: true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("AttackDown");
                if (_triggerController != null)
                {
                    _triggerController.ActivateTrigger();
                }
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