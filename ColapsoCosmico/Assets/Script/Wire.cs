using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireIndex; // �ndice do fio
    private TaskControllerEnergy playerController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        playerController = FindObjectOfType<TaskControllerEnergy>(); // Encontra o PlayerController na cena
 
    }

    void OnMouseDown()
    {
        Debug.Log("Fio clicado: " + wireIndex);
        playerController.CutWire(wireIndex); // Chama o m�todo CutWire no PlayerController
        
    }
}
