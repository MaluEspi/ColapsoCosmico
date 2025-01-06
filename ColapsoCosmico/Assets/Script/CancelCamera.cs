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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.E))
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
         Cursor.lockState = CursorLockMode.None;
        playerMain.GetComponent<Animator>().enabled = false;
        playerMain.GetComponent<CameraMove>().enabled = false;
        playerMain.GetComponent<PlayerMovementWZeroGravity>().enabled = false;
  
        isMovementDisabled = true; // Atualiza o estado para desabilitado
    }

    public void EnableMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMain.GetComponent<Animator>().enabled = true;
        playerMain.GetComponent<CameraMove>().enabled = true;
        playerMain.GetComponent<PlayerMovementWZeroGravity>().enabled = true;
     
        isMovementDisabled = false; // Atualiza o estado para habilitado
    }
}
