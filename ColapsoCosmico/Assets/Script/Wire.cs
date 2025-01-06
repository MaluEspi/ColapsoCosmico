using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireIndex; // Índice do fio
    private TaskControllerEnergy playerController;

    void Start()
    {
        playerController = FindObjectOfType<TaskControllerEnergy>(); // Encontra o PlayerController na cena
 
    }

    void OnMouseDown()
    {
        Debug.Log("Fio clicado: " + wireIndex);
        playerController.CutWire(wireIndex); // Chama o método CutWire no PlayerController
        
    }
}
