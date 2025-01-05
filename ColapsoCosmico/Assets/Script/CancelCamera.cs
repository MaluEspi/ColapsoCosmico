using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCamera : MonoBehaviour
{
    public GameObject playerMain;
    private bool isMovementDisabled = false;

    private void Start()
    {
      //  Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 é o botão esquerdo do mouse
        {
            Cursor.lockState = CursorLockMode.None;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.transform == transform) // Verifica se o objeto clicado é este
                {
                   
                    DisableMovement();
                }
                else if (isMovementDisabled)
                {
                    EnableMovement();
                }
            }
        }
       
    }
    private void DisableMovement()
    {
        playerMain.GetComponent<Animator>().enabled = false;
        playerMain.GetComponent<CameraMove>().enabled = false;
        playerMain.GetComponent<PlayerMovementWZeroGravity>().enabled = false;
  
        isMovementDisabled = true; // Atualiza o estado para desabilitado
    }

    private void EnableMovement()
    {
        playerMain.GetComponent<Animator>().enabled = true;
        playerMain.GetComponent<CameraMove>().enabled = true;
        playerMain.GetComponent<PlayerMovementWZeroGravity>().enabled = true;
     
        isMovementDisabled = false; // Atualiza o estado para habilitado
    }
}
