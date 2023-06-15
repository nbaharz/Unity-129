using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed; // Karakterin hareket hızı
    public float jumpForce; // Zıplama kuvveti
    //private bool isJumping = false; // Zıplama durumu kontrolü

    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityÇarpanı;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Yatay hareket için Input
        float moveZ = Input.GetAxis("Vertical"); // Dikey hareket için Input

        // Hareket yönünü hesapla
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical")* moveSpeed);
        

        // Zıplama kontrolü
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        // Hareket uygula
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityÇarpanı * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
