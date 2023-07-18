using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // move speed deðiþkeni tanýmlar
    public float MoveSpeed;
    // jump speed deðiþkeni tanýmlar
    public float JumpSpeed;

    // rigidbody deðiþkeni tanýmlar
    public Rigidbody RB;
    void Start()
    {
        // scripte sahip olan game objectinin rigidbodysini alýr ve RB deðiþkenine girer
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
