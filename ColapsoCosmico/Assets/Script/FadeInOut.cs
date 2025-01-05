using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup canvasgroup;

    public bool fadeIn = false;
    public bool fadeOut = false;

    public float timeToFade;

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            if (canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += timeToFade * Time.deltaTime;
                if (canvasgroup.alpha >= 1)
                {
                    canvasgroup.alpha = 1; // Garante que não passe de 1
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (canvasgroup.alpha > 0)
            {
                canvasgroup.alpha -= timeToFade * Time.deltaTime;
                if (canvasgroup.alpha <= 0)
                {
                    canvasgroup.alpha = 0; // Garante que não passe de 0
                    fadeOut = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
        fadeOut = false; // Evitar conflitos com o fadeOut
        Debug.Log("FadeIn ativado"); // Verificação
    }

    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false; // Evitar conflitos com o fadeIn
        Debug.Log("FadeOut ativado"); // Verificação
    }
}