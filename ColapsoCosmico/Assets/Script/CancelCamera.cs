using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCamera : MonoBehaviour
{
    private CameraMove cameraMove;
    private PlayerMovement playerMovement;
    private bool isMovementDisabled = false;

    private void Start()
    {
        cameraMove = FindObjectOfType<CameraMove>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 é o botão esquerdo do mouse
        {
          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("mouse detectado");
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
        cameraMove.CancelCamera(value: false);
        playerMovement.CancelMove(value: false);
        isMovementDisabled = true; // Atualiza o estado para desabilitado
    }

    private void EnableMovement()
    {
        cameraMove.CancelCamera(value: true);
        playerMovement.CancelMove(value: true);
        isMovementDisabled = false; // Atualiza o estado para habilitado
    }
}
