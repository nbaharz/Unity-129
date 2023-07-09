using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup : MonoBehaviour
{
    public GameObject keyIcon; // Sað üst köþede görünecek olan anahtar simgesi

    public bool hasKey = false; // Baþlangýçta anahtar yok, kapý açma fonksiyonunda bu variable kontrol edilecek

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Anahtara Player tag'iyle bir nesne çarpýþýrsa olacaklar:
        {
            hasKey = true; // Artýk Anahtar var
            keyIcon.SetActive(true); // Anahtar simgesini aktifleþtir
            gameObject.SetActive(false); // Anahtar nesnesini etkisiz hale getir, ekranda görünmez
        }
    }
}


