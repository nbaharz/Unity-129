using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Animator FadeAnimatorController;
    ReloadScene fade;
    public float fadeOutDuration = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FadeAnimatorController.SetBool("PlayerDetected", true);
            StartCoroutine(ChangeScene());
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FadeAnimatorController.SetBool("PlayerDetected", false);
        }
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   

}
