using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody bile�eni

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bile�enini al
    }

    public void Push(Vector3 pushDirection, float pushForce)
    {
        if (rb != null)
        {
            // �tme i�lemini ger�ekle�tirir
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Hareketin yava�lamas� ve momentumunun azalmas� i�in s�rt�nme uygula
        if (rb != null)
        {
            rb.velocity *= 0.95f;
        }
    }
}
