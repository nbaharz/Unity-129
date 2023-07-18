using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    public KeyCode pushKey = KeyCode.Q;
    public GameObject playerObject;
    public GameObject pushableObject;
    public Animator playerAnimator;
    private bool isPushing = false;

    private void Update()
    {
        if (Input.GetKeyDown(pushKey))
        {
            if (isPushing)
            {
                DetachObjects();
            }
            else
            {
                AttachObjects();
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

    private void OnTriggerEnter(Collider other)
    {
        if (!isPushing && other.gameObject == pushableObject)
        {
            AttachObjects();
        }
    }

    private void AttachObjects()
    {
        Rigidbody pushableRigidbody = pushableObject.GetComponent<Rigidbody>();
        if (pushableRigidbody != null)
        {
            pushableRigidbody.isKinematic = true;
        }
        pushableObject.transform.parent = playerObject.transform;
        isPushing = true;
    }

    private void DetachObjects()
    {
        Rigidbody pushableRigidbody = pushableObject.GetComponent<Rigidbody>();
        if (pushableRigidbody != null)
        {
            pushableRigidbody.isKinematic = false;
        }
        pushableObject.transform.parent = null;
        isPushing = false;
    }

}
