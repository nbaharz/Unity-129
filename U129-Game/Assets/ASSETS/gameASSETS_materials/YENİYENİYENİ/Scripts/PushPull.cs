using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PushableCollision : MonoBehaviour
{
    public KeyCode pushKey = KeyCode.Q;
    public GameObject[] pushableObjects; //Birden fazla pushable obje eklenmesi için []
   public Animator characterAnimator;

    private bool isPushing = false;

    private void Update()
    {
        if (Input.GetKeyDown(pushKey))
        {
            if (isPushing)
            {
                DetachObjects(); // Q'ya basildiginda karakter objesi ile pushable obje kenetlenir ve beraber hareket ederler.
                StopMovingAnimation();
            }
            else
            {
                AttachObjects();
                 PlayMovingAnimation();
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (isPushing)
        {
            
            if (vertical > 0)
            {
                MoveForwardAnimation();
            }
            else if (vertical < 0)
            {
                MoveBackwardAnimation();
            }

            
            if (horizontal > 0)
            {
                MoveRightAnimation();
            }
            else if (horizontal < 0)
            {
                MoveLeftAnimation();
            }
        }
    }

    private void AttachObjects()
    {
        foreach (GameObject pushableObject in pushableObjects)
        {
            Rigidbody pushableRigidbody = pushableObject.GetComponent<Rigidbody>();
            if (pushableRigidbody != null)
            {
                pushableRigidbody.isKinematic = true;
            }
            pushableObject.transform.parent = transform;
        }
        isPushing = true;
    }

    private void DetachObjects()
    {
        foreach (GameObject pushableObject in pushableObjects)
        {
            Rigidbody pushableRigidbody = pushableObject.GetComponent<Rigidbody>();
            if (pushableRigidbody != null)
            {
                pushableRigidbody.isKinematic = false;
            }
            pushableObject.transform.parent = null;
        }
        isPushing = false;
    }

    private void PlayMovingAnimation() //Animasyonlar henüz eklenmedi.
    {
        characterAnimator.SetBool("IsMoving", true);
    }

    private void StopMovingAnimation()
    {
        characterAnimator.SetBool("IsMoving", false);
    }

    private void MoveForwardAnimation()
    {
        characterAnimator.SetFloat("MoveSpeed", 1f);
    }

    private void MoveBackwardAnimation()
    {
        characterAnimator.SetFloat("MoveSpeed", -1f);
    }

    private void MoveRightAnimation()
    {
        characterAnimator.SetFloat("StrafeSpeed", 1f);
    }

    private void MoveLeftAnimation()
    {
        characterAnimator.SetFloat("StrafeSpeed", -1f);
    }
}

