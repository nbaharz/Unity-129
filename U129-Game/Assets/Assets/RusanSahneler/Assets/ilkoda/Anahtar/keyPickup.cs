using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyPickup : MonoBehaviour
{
    public GameObject keyIcon; // Sa� �st k��ede g�r�necek olan anahtar simgesi

    public bool hasKey = false; // Ba�lang��ta anahtar yok, kap� a�ma fonksiyonunda bu variable kontrol edilecek

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Anahtara Player tag'iyle bir nesne �arp���rsa olacaklar:
        {
            hasKey = true; // Art�k Anahtar var
            keyIcon.SetActive(true); // Anahtar simgesini aktifle�tir
            gameObject.SetActive(false); // Anahtar nesnesini etkisiz hale getir, ekranda g�r�nmez
        }
    }
}


