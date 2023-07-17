using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PickUpPaper : MonoBehaviour
{
    public GameObject instruction; // "Read the letter" 
    public GameObject directionalLight; 
    public GameObject readPaper; // Mektup canvas görseli
    public GameObject quitPaper; // Mektuptan çıkma texti
    public GameObject arrow;
    public bool getPaper = false; // Mektubu alabilecek alanda bulunup bulunmama durumu
    
    public float intensityDecreaseAmount = 0.3f;
    void Start()
    {
        arrow.SetActive(true);
        quitPaper.SetActive(false);
        readPaper.SetActive(false);
        instruction.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arrow.SetActive(false);
            getPaper = true;
            Debug.Log("hasPaper");
            instruction.SetActive(true);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Mektuptan uzaklaştığında
        {
           
            getPaper = false;
            instruction.SetActive(false);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && getPaper) 
        {
           quitPaper.SetActive(true);
           readPaper.SetActive(true);
           instruction.SetActive(false);
            arrow.SetActive(false);
            
        }
        if (Input.GetKeyDown(KeyCode.Escape) && getPaper)
        {
            getPaper = false;
            quitPaper.SetActive(false);
            readPaper.SetActive(false);
            instruction.SetActive(false);
            directionalLight.GetComponent<Light>().intensity -= intensityDecreaseAmount;
            
        }
    }
}
