using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AraSahne : MonoBehaviour
{
    [SerializeField] GameObject image1;
    [SerializeField] GameObject image2;
    [SerializeField] GameObject image3;
    [SerializeField] GameObject image4;
    [SerializeField] GameObject image5;
    [SerializeField] GameObject image6;
    [SerializeField] GameObject image7;
    [SerializeField] GameObject image8;
    [SerializeField] GameObject image9;
    [SerializeField] GameObject image10;

    [SerializeField] bool g1, g2, g3, g4, g5, g6, g7, g8, g9, g10;
    public void Awake()
    {

        g1 = true;
        g2 = false;
        g3 = false;
        g4 = false;
        g5 = false;
        g6 = false;
        g7 = false;
        g8 = false;
        g9 = false;
        g10 = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && g1 == true)
        {
            image1.SetActive(true);
            g1 = false;
            g2 = true;

        }

        else if (Input.GetMouseButtonDown(0) && g2 == true)
        {
            image2.SetActive(true);
            image1.SetActive(false);
            g2 = false;
            g3 = true;


        }

        else if (Input.GetMouseButtonDown(0) && g3 == true)
        {
            image3.SetActive(true);
            image2.SetActive(false);
            g3 = false;
            g4 = true;


        }

        else if (Input.GetMouseButtonDown(0) && g4 == true)
        {

            image4.SetActive(true);
            image3.SetActive(false);
            g4 = false;
            g5 = true;
        }
        else if (Input.GetMouseButtonDown(0) && g5 == true)
        {

            image5.SetActive(true);
            image4.SetActive(false);
            g5 = false;
            g6 = true;
        }
        else if (Input.GetMouseButtonDown(0) && g6 == true)
        {

            image6.SetActive(true);
            image5.SetActive(false);
            g6 = false;
            g7 = true;
        }
        else if (Input.GetMouseButtonDown(0) && g7 == true)
        {

            image7.SetActive(true);
            image6.SetActive(false);
            g7 = false;
            g8 = true;
        }
        else if (Input.GetMouseButtonDown(0) && g8 == true)
        {

            image8.SetActive(true);
            image7.SetActive(false);
            g8 = false;
            g9 = true;
        }
        else if (Input.GetMouseButtonDown(0) && g9 == true)
        {

            image9.SetActive(true);
            image8.SetActive(false);
            g9 = false;
            g10 = true;
        }
        else if (Input.GetMouseButtonDown(0) && g10 == true)
        {

            image10.SetActive(true);
            image9.SetActive(false);
            g10 = false;
            Invoke("SahneGeçiş", 2f);
        }
    }
    private void SahneGeçiş()
    {
        SceneManager.LoadScene(2);
    }
}
