using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPickupNew : MonoBehaviour
{
    public Animator keyAnimator; // Anahtar animasyonunu kontrol eden Animator bileşeni
    public GameObject keyObject;
    public GameObject pickUpText;
    //public Image keyIcon; // Anahtar simgesi için Image öğesi
    public static bool hasKey = false; // Başlangıçta anahtar yok

    private void Start()
    {
        pickUpText.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Anahtara Player tag'iyle bir nesne çarparsa
        {
            hasKey = true;
            pickUpText.SetActive(true); // Metin öğesini etkinleştir
            // Artık anahtar var
            // Anahtar nesnesini etkisiz hale getir, sahnede görünmez
            //keyAnimator.SetBool("isKey", true); // Anahtar animasyonunu tetikle 

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Anahtardan uzaklaşıldığında
        {
            hasKey = false; // Anahtar yok
            pickUpText.SetActive(false); // Metin öğesini devre dışı bırak
        }
    }
    public void Update()
    {
        if (hasKey && Input.GetKeyDown(KeyCode.Q)) // Eğer anahtar alındıysa ve E tuşuna basıldıysa
        {
            pickUpText.SetActive(false);
            keyObject.SetActive(false); // Anahtar nesnesini etkisiz hale getir, sahnede görünmez
            keyAnimator.SetBool("isKey", true); // Anahtar animasyonunu tetikle
        }
    }
}
