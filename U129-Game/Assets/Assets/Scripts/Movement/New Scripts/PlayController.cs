using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotationSpeed = 500f;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundlayer;
    
    private float jumpHeight = 1f;
    private float gravity_ = -10f;
    bool isGrounded;
    float ySpeed;
    CharacterController controller;
    
    Quaternion targetRotation;

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) +Mathf.Abs(v));
        var moveInput = (new Vector3(h, 0, v)).normalized;

        GroundCheck();
        //Debug.Log("IsGrounded = " + isGrounded);

        if (isGrounded)
        {
            //Debug.Log("Grounded");
            ySpeed = 0f;
            if(Input.GetButtonDown("Jump"))
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity_);
                animator.SetBool("isJumped", true);
                Debug.Log("Jumped");
            }
            else
            {
                animator.SetBool("isJumped", false);
            }
        }
        else
        {
            ySpeed += gravity_* Time.deltaTime;
            animator.SetBool("isJumped", false);
        }
        var velocity = moveInput * moveSpeed * 2.5f;
        velocity.y = ySpeed;
        
        controller.Move(velocity * Time.deltaTime);
        
        if (moveAmount > 0)
        {
            //transform.position += moveInput * moveSpeed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(moveInput);
        }
        transform.rotation= Quaternion.RotateTowards(transform.rotation, targetRotation,rotationSpeed*Time.deltaTime);
        
        animator.SetFloat("moveAmount", moveAmount,0.2f,Time.deltaTime);
    }
    void GroundCheck()
    {
        isGrounded= Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundlayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }
}
