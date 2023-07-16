using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithAnim : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;

    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            movement += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            movement += Vector3.right;
        if (Input.GetKey(KeyCode.W))
            movement += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            movement += Vector3.back;

        movement = movement.normalized * speed * Time.deltaTime;

        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime));

        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // Yürüme animasyonunu kontrol etmek için hızı ayarla
        float movementMagnitude = movement.magnitude;
        animator.SetFloat("Speed", movementMagnitude);
    }
}
