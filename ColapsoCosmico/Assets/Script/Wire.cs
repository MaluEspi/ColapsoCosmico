using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireIndex; // Índice do fio
    private TaskControllerEnergy playerController;

    void Start()
    {
//<<<<<<< HEAD
        Cursor.lockState = CursorLockMode.None;
//=======
//>>>>>>> 6726a64c13f63dee31c943dea599489540107c93
        playerController = FindObjectOfType<TaskControllerEnergy>(); // Encontra o PlayerController na cena
 
    }

    void OnMouseDown()
    {
        Debug.Log("Fio clicado: " + wireIndex);
        playerController.CutWire(wireIndex); // Chama o método CutWire no PlayerController
        
    }
}
