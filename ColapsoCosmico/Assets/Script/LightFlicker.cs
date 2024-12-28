using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light myLight;

     float interval = 2;
     float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if( timer > interval)
        {
            myLight.enabled = !myLight.enabled;
            interval = Random.Range(0f, 2f);
            timer = 0;
        }
    }
}
