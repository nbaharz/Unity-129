using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    string playerTag;
    Transform lens;
    //[SerializeField] Animator FadeAnimController; //
    // Start is called before the first frame update
    void Start()
    {
        //Canvas canvas = GetComponent<Canvas>();

        // 
        //Color canvasColor = canvas.GetComponent<Graphic>().color;

        // 
        //canvasColor.a = 0f;

        // 
        //canvas.GetComponent<Graphic>().color = canvasColor;

        lens = transform.parent.GetComponent<Transform>();
        playerTag = GameObject.FindGameObjectWithTag("Player").tag;
        //FadeAnimController.SetBool("PlayerDetected", false);
    }

    // Update is called once per frame
    void OnTriggerStay (Collider col)
    {
        if (col.gameObject.tag == playerTag)
        {
            Vector3 direction = col.transform.position - lens.position;
            RaycastHit hit;
            
            if (Physics.Raycast(lens.transform.position,direction.normalized,out hit,1000))
            {
                Debug.Log(hit.collider.name);
               // FadeAnimController.SetBool("PlayerDetected", true); //
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name); //

            }
         
        }
    }
}
