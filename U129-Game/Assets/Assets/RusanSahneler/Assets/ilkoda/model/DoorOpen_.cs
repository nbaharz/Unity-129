using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpen_ : MonoBehaviour
{
    //Anahtarla kapıyı açma ve sahne geçiş animasyonları
   
    public bool hasKey_;
    public GameObject DoorUnlocked; //Anahtar yokken kapının kilitli olduğunu gösterir
    public GameObject DoorLocked; // Kapıdan geçilebileceğini gösterir.
    public Animator FadeAnim; // Sahne açılış kapanış kararma efekti
    
    void Start()
    {
        DoorLocked.SetActive(false);
        DoorUnlocked.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))// Kapı ile oyuncunun çarpışması
        {
            if (hasKey_)
            {
                DoorUnlocked.SetActive(true);
            }
            if (!hasKey_)
            {
                DoorLocked.SetActive(true);
            }

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Kapıdan uzaklaşıldığında
        {
            DoorUnlocked.SetActive(false);
            DoorLocked.SetActive(false);
        }
    }
    public void Update()
    {
        hasKey_ = keyPickupNew.hasKey;
        if (hasKey_ && Input.GetKeyDown(KeyCode.E))
        {
            DoorUnlocked.SetActive(false);
            DoorLocked.SetActive(false);
            StartCoroutine(ChangeScene()); // ChangeScene Coroutine'unu başlat
        }
    }

    public IEnumerator ChangeScene()
    {
        FadeAnim.SetTrigger("FadeOut"); // FadeOut animasyonunu tetikle
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MorgSahnesi");
    }
}
