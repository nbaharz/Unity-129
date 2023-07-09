using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BU SCRİPT TEMEL YÖNLERE HAREKET ETMEYİ VE ZIPLAMAYI SAĞLIYOR. ANİMASYON ÖGELERİ KAPALI VE HAREKET SCRİPTİNDE HERHANGİ BİR SORUN OLUSMUYOR.

public class CharacterMovementTemel : MonoBehaviour
{
    public float moveSpeed; // Karakterin hareket hızı
    public float jumpForce; // Zıplama kuvveti
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityÇarpanı;
    //public Animator anim;
        void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {

        // Hareket yönünü hesapla
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                //anim.SetBool("grounded", false);
                moveDirection.y = jumpForce;
                //animator.SetBool("jumpbool",true);
                //animator.SetBool("grounded", false);        
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityÇarpanı * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //anim.SetBool("grounded", controller.isGrounded);
        //anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical"))+ Mathf.Abs(Input.GetAxis("Horizontal"))));
        
     
        //animator.SetFloat("speed", Mathf.Abs(controller.velocity.x) + Mathf.Abs(controller.velocity.z));
        
    }


}
