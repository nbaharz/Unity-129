using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNote : MonoBehaviour
{
    //Oyuncunun notu okumadan odadan çıkmasını engelleyen script.
    public Light _light;
    public GameObject checkNote;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_light.intensity < 0.04)
        {
            Destroy(checkNote);
        }
    }
}
