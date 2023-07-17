using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    // Işığın kesik kesik yanmasını sağlayan script

    public Light _light;
    public float MinTime;
    public float MaxTime;
    public float Timer;
    
    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (_light.intensity <0.04)
        FlickerLight();
    }
    void FlickerLight()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer<= 0)
        {
            _light.enabled = !_light.enabled;
            Timer = Random.Range(MinTime, MaxTime);

        }
    }
}
