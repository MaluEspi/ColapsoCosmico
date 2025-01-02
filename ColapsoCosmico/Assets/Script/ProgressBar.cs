using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image barraProgresso; // Referência à barra de progresso
    public float larguraOriginal; // Largura original da barra

    void Start()
    {
        larguraOriginal = barraProgresso.rectTransform.sizeDelta.x; // Armazena a largura original
        barraProgresso.rectTransform.sizeDelta = new Vector2(larguraOriginal, barraProgresso.rectTransform.sizeDelta.y); // Define a largura inicial
    }

    public void DiminuirBarra(float quantidade)
    {
        // Diminui a largura da barra
        float novaLargura = barraProgresso.rectTransform.sizeDelta.x - quantidade; // Diminui a quantidade especificada
        novaLargura = Mathf.Max(novaLargura, 0); // Garante que não fique negativa
        barraProgresso.rectTransform.sizeDelta = new Vector2(novaLargura, barraProgresso.rectTransform.sizeDelta.y);
    }

    public void ReiniciarBarra()
    {
        barraProgresso.rectTransform.sizeDelta = new Vector2(larguraOriginal, barraProgresso.rectTransform.sizeDelta.y); // Reseta a largura
    }
}
