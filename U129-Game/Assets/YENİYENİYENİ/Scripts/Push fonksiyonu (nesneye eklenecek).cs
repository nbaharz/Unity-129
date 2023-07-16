using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody bileþeni

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileþenini al
    }

    public void Push(Vector3 pushDirection, float pushForce)
    {
        if (rb != null)
        {
            // Ýtme iþlemini gerçekleþtirir
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Hareketin yavaþlamasý ve momentumunun azalmasý için sürtünme uygula
        if (rb != null)
        {
            rb.velocity *= 0.95f;
        }
    }
}
