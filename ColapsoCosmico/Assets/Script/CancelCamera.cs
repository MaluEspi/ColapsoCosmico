using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCamera : MonoBehaviour
{
    public GameObject playerMain;
    private bool isMovementDisabled = false;

    private void Start()
    {
      
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 é o botão esquerdo do mouse
        {
          
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
        if (isMovementDisabled)
        {
            Camera.main.transform.position = new Vector3(20.69f, 0.595f, 14.69f);
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0); // Ajuste a rotação se necessário
        }

    }
    private void DisableMovement()
    {
        playerMain.GetComponent<Animator>().enabled = false;
        playerMain.GetComponent<CameraMove>().enabled = false;
        playerMain.GetComponent<PlayerMovement>().enabled = false;
  
        isMovementDisabled = true; // Atualiza o estado para desabilitado
    }

    private void EnableMovement()
    {
        playerMain.GetComponent<Animator>().enabled = true;
        playerMain.GetComponent<CameraMove>().enabled = true;
        playerMain.GetComponent<PlayerMovement>().enabled = true;
     
        isMovementDisabled = false; // Atualiza o estado para habilitado
    }
}
