using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartSceneYEDEK : MonoBehaviour
{
    public Text infoText; // Düşme metnini gösterecek olan UI Text nesnesi.

    private bool showText = false; // Düşme metnini gösterme durumunu tutacak boolean değişken.
    private bool düştükMü = false;



    private void OnEnable()
    {
        // SceneManager.sceneLoaded olayına abone olunur.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // SceneManager.sceneLoaded olayından abonelik kaldırılır.
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {

        if (showText)
        {
            // Düşme metni gösteriliyor ve süre kontrol ediliyor.
            if (Time.timeSinceLevelLoad >= 2f)
            {
                // Belirtilen süre geçtiğinde düşme metni devre dışı bırakılıyor.
                infoText.gameObject.SetActive(false);
                showText = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            düştükMü = true; // daha önce düşüp düşmediğimizi kontrol eder, ona göre ilk sahnede metni göstermez

            // Karakter düşme alanına temas ettiğinde sahne yeniden yüklenir.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (düştükMü)
        {
            // Sahne yüklendiğinde düşme metni gösterme durumu true yapılır ve metin görünür hale getirilir.
            showText = true;
            infoText.gameObject.SetActive(true);
        }
    }
}
