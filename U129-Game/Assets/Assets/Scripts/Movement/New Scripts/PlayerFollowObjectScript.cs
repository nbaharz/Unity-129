using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// KAM 
public class PlayerFollowObjectScript : MonoBehaviour
{
    public Transform characterTransform;
    public float maxDistanceFromCharacter = 2.0f; // Maksimum mesafe
    public float distanceFromCharacter = 1.0f; // Baþlangýç mesafesi
    public float zAxisMultiplier = 0.5f; // Z eksenindeki hareket çarpaný

    private Vector3 initialOffset;

    private void Start()
    {
        // Baþlangýçta karakter ve obje arasýndaki mesafeyi hesapla
        initialOffset = transform.position - characterTransform.position;
    }

    private void Update()
    {
        // Karakterin hareket yönünü al
        Vector3 characterDirection = characterTransform.forward;

        // Yatay ekseni dikkate alarak objenin yatay konumunu hesapla
        Vector3 horizontalOffset = characterDirection * distanceFromCharacter;

        // Diðer eksenlerdeki konumu ayný tutarak objeyi güncelle
        Vector3 targetPosition = new Vector3(transform.position.x, characterTransform.position.y, characterTransform.position.z) + horizontalOffset + initialOffset;

        // Maksimum mesafeyi kontrol et ve objenin konumunu sýnýrla
        float distance = Vector3.Distance(characterTransform.position, targetPosition);
        if (distance > maxDistanceFromCharacter)
        {
            targetPosition = characterTransform.position + characterDirection * maxDistanceFromCharacter + initialOffset;
        }

        // Z ekseni hareketine çarpan uygula
        targetPosition.z = characterTransform.position.z + (targetPosition.z - characterTransform.position.z) * zAxisMultiplier;

        transform.position = targetPosition;
    }
}




