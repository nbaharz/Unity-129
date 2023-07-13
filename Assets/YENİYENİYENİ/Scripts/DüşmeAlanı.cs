using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScene : MonoBehaviour
{
    public Text infoText;
    private bool showText = false;
    private float textTimer = 0f;

    private void Update()
    {
        if (showText)
        {
            textTimer += Time.deltaTime;
            if (textTimer >= 2f)
            {
                infoText.gameObject.SetActive(false);
                showText = false;
                textTimer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        showText = true;
        infoText.gameObject.SetActive(true);
    }
}
