using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pullpush : MonoBehaviour
{
    public KeyCode pushKey = KeyCode.Q;
    public GameObject playerObject;
    public Animator playerAnimator;
    private bool isPushing = false;

    private void Update()
    {
        if (Input.GetKeyDown(pushKey))
        {
            if (isPushing)
            {
                DetachObject();
            }
            else
            {
                AttachObject();
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (isPushing)
        {
            Vector3 movement = new Vector3(horizontal, 0f, vertical) * Time.deltaTime;
            playerObject.transform.position += movement;
        }

        playerAnimator.SetBool("isPushing", isPushing);
    }

    private void AttachObject()
    {
        isPushing = true;
    }

    private void DetachObject()
    {
        isPushing = false;
    }
}


