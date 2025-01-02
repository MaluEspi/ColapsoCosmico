using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTransparency : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public float speed = 2f;
    public float minAlpha = 70f / 255f; 
    public float maxAlpha = 1f; 

    private bool fadingOut = true; 

    void Update()
    {
       
        Color color = spriteRenderer.color;

        if (fadingOut)
        {
            color.a -= speed * Time.deltaTime;
            if (color.a <= minAlpha)
            {
                color.a = minAlpha;
                fadingOut = false;
            }
        }
        else
        {
            color.a += speed * Time.deltaTime;
            if (color.a >= maxAlpha)
            {
                color.a = maxAlpha;
                fadingOut = true;
            }
        }

        spriteRenderer.color = color;
    }
}
