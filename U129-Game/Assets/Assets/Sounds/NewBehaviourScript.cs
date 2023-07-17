using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Update is called once per frame
    public AudioSource footStepsSound;
    void Update()
    {
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footStepsSound.enabled = true;
        }
        else
        {
            footStepsSound.enabled = false;
        }
    }
}
