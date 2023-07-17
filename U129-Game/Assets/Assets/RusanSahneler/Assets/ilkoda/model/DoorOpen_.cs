using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpen_ : MonoBehaviour
{
    public Animator animator;
    public bool hasKey_;
    public GameObject DoorUnlocked;
    public GameObject DoorLocked;
    // Start is called before the first frame update
    void Start()
    {
        DoorLocked.SetActive(false);
        DoorUnlocked.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))// Anahtara Player tag'iyle bir nesne çarparsa
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
        if (other.CompareTag("Player")) // Anahtardan uzaklaşıldığında
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
            SceneManager.LoadScene("MorgSahnesi");

        }

    }
}
