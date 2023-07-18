using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // move speed de�i�keni tan�mlar
    public float MoveSpeed;
    // jump speed de�i�keni tan�mlar
    public float JumpSpeed;

    // rigidbody de�i�keni tan�mlar
    public Rigidbody RB;
    void Start()
    {
        // scripte sahip olan game objectinin rigidbodysini al�r ve RB de�i�kenine girer
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RB.velocity = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, RB.velocity.y, Input.GetAxis("Vertical") * MoveSpeed);
        
        if(Input.GetButtonDown("Jump"))
        {
            RB.velocity = new Vector3(RB.velocity.x, JumpSpeed, RB.velocity.z);
        }
    
    }
}
