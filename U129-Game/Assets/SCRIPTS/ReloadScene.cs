using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] private Animator FadeAnimatorController;
    ReloadScene fade;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FadeAnimatorController.SetBool("PlayerDetected", true);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            FadeAnimatorController.SetBool("PlayerDetected", false);
        }
    }
   
}
