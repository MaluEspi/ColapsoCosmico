using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Camera playerCamera; // A câmera do jogador
    private bool isInteracting = false; // Variável para controlar a interação

    void Update()
    {
        // Verifica se o jogador está interagindo
        if (isInteracting)
        {
            // Aqui você pode adicionar a lógica de interação com o objeto
            // Por exemplo, se o jogador pressionar um botão para interagir
            if (Input.GetKeyDown(KeyCode.E)) // Supondo que 'E' seja a tecla de interação
            {
                InteractWithObject();
            }
        }
        else
        {
            // Lógica de movimentação da câmera
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        // Lógica para mover a câmera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Aqui você pode adicionar a lógica de rotação da câmera
        playerCamera.transform.Rotate(-mouseY, mouseX, 0);
    }

    void InteractWithObject()
    {
        // Lógica para interagir com o objeto
        Debug.Log("Interagindo com o objeto!");

        // Após a interação, você pode definir isInteracting como false
        // Se a interação for temporária, você pode usar um Coroutine ou um Timer
        isInteracting = false; // Defina como false quando a interação terminar
    }

    // Método para iniciar a interação
    public void StartInteraction()
    {
        isInteracting = true;
    }

    // Método para terminar a interação
    public void EndInteraction()
    {
        isInteracting = false;
    }
}

