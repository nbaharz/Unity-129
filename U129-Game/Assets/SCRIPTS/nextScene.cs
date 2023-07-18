using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    [SerializeField] private string newLevel;
    [SerializeField] private GameObject uiElement;
    public Animator FadeAnim;

    private void Start()
    {
        uiElement.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                StartCoroutine(ChangeScene());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiElement.SetActive(false);
        }
    }
    public IEnumerator ChangeScene()
    {
        FadeAnim.SetTrigger("FadeOut"); // FadeOut animasyonunu tetikle
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(newLevel);
    }
}
