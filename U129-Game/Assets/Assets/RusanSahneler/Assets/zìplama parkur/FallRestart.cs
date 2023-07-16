using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallRestart : MonoBehaviour
{
    private string currentSceneName;
    private Vector3 playerStartPosition;

    private void Start()
    {
        // Oyuncu başlangıç konumunu kaydet
        playerStartPosition = transform.position;

        // Mevcut sahne adını kaydet
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            // Oyuncu konumunu başlangıç konumuna geri yükle
            transform.position = playerStartPosition;

            // Mevcut sahneyi yeniden yükle
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
