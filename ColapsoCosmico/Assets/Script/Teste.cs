using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Camera playerCamera; // A c�mera do jogador
    private bool isInteracting = false; // Vari�vel para controlar a intera��o

    void Update()
    {
        // Verifica se o jogador est� interagindo
        if (isInteracting)
        {
            // Aqui voc� pode adicionar a l�gica de intera��o com o objeto
            // Por exemplo, se o jogador pressionar um bot�o para interagir
            if (Input.GetKeyDown(KeyCode.E)) // Supondo que 'E' seja a tecla de intera��o
            {
                InteractWithObject();
            }
        }
        else
        {
            // L�gica de movimenta��o da c�mera
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        // L�gica para mover a c�mera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Aqui voc� pode adicionar a l�gica de rota��o da c�mera
        playerCamera.transform.Rotate(-mouseY, mouseX, 0);
    }

    void InteractWithObject()
    {
        // L�gica para interagir com o objeto
        Debug.Log("Interagindo com o objeto!");

        // Ap�s a intera��o, voc� pode definir isInteracting como false
        // Se a intera��o for tempor�ria, voc� pode usar um Coroutine ou um Timer
        isInteracting = false; // Defina como false quando a intera��o terminar
    }

    // M�todo para iniciar a intera��o
    public void StartInteraction()
    {
        isInteracting = true;
    }

    // M�todo para terminar a intera��o
    public void EndInteraction()
    {
        isInteracting = false;
    }
}

