using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public int wireIndex; // �ndice do fio
    private EnergyTaskController playerController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        playerController = FindObjectOfType<EnergyTaskController>(); // Encontra o PlayerController na cena
        OnMouseDown();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // 0 � o bot�o esquerdo do mouse
        {
            playerController.CutWire(wireIndex); // Chama o m�todo CutWire no PlayerController
        }
    }
}
