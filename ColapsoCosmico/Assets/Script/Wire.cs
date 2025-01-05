using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireIndex; // Índice do fio
    private EnergyTaskController playerController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        playerController = FindObjectOfType<EnergyTaskController>(); // Encontra o PlayerController na cena
        OnMouseDown();
    }

    void OnMouseDown()
    {
        Debug.Log("Fio clicado: " + wireIndex);
        playerController.CutWire(wireIndex); // Chama o método CutWire no PlayerController
        
    }
}
