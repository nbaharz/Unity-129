using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCameraFollow : MonoBehaviour
{
    public Vector3 minCameraPosition; // Minimum kamera konumu (x ve y)
    public Vector3 maxCameraPosition;
    public Transform characterTransform;
    public float maxDistanceFromCharacter = 2.0f; // Maksimum mesafe
    public float distanceFromCharacter = 1.0f; // Ba�lang�� mesafesi
    public float zAxisMultiplier = 0.5f; // Z eksenindeki hareket �arpan�

    private Vector3 initialOffset;

    private void Start()
    {
        // Ba�lang��ta karakter ve obje aras�ndaki mesafeyi hesapla
        initialOffset = transform.position - characterTransform.position;
    }

    private void Update()
    {
        // Karakterin hareket y�n�n� al
        Vector3 characterDirection = characterTransform.forward;

        // Yatay ekseni dikkate alarak objenin yatay konumunu hesapla
        Vector3 horizontalOffset = characterDirection * distanceFromCharacter;

        // Di�er eksenlerdeki konumu ayn� tutarak objeyi g�ncelle
        Vector3 targetPosition = new Vector3(transform.position.x, characterTransform.position.y, characterTransform.position.z) + horizontalOffset + initialOffset;

        // Maksimum mesafeyi kontrol et ve objenin konumunu s�n�rla
        float distance = Vector3.Distance(characterTransform.position, targetPosition);
        if (distance > maxDistanceFromCharacter)
        {
            targetPosition = characterTransform.position + characterDirection * maxDistanceFromCharacter + initialOffset;
        }

        // Z ekseni hareketine �arpan uygula
        targetPosition.z = characterTransform.position.z + (targetPosition.z - characterTransform.position.z) * zAxisMultiplier;

        transform.position = targetPosition;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minCameraPosition.x, maxCameraPosition.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minCameraPosition.y, maxCameraPosition.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minCameraPosition.z, maxCameraPosition.z);
        transform.position = clampedPosition;
    }
}
