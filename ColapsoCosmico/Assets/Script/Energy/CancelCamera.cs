using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelCamera : MonoBehaviour
{
    public GameObject playerMain; // Refer�ncia ao objeto do jogador
    private bool isMovementDisabled = false;

    private void Start()
    {
        // Cursor.lockState = CursorLockMode.None; 

    }
    private void Update()
    {
        // Verifica se a c�mera principal est� dispon�vel
        if (Camera.main == null)
        {
            return; // Sai do m�todo se a c�mera n�o estiver dispon�vel
        }

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform == transform) // Verifica se o objeto clicado � este
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

        // Verifica se playerMain n�o � nulo antes de acessar seus componentes
        if (playerMain != null)
        {
            Animator animator = playerMain.GetComponent<Animator>();
            CameraMove cameraMove = playerMain.GetComponent<CameraMove>();
            PlayerMovementWZeroGravity playerMovement = playerMain.GetComponent<PlayerMovementWZeroGravity>();

            if (animator != null) animator.enabled = false;
            if (cameraMove != null) cameraMove.enabled = false;
            if (playerMovement != null) playerMovement.enabled = false;
        }
        else
        {
            Debug.LogWarning("playerMain n�o est� atribu�do.");
        }

        isMovementDisabled = true; // Atualiza o estado para desabilitado
    }

    public void EnableMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Verifica se playerMain n�o � nulo antes de acessar seus componentes
        if (playerMain != null)
        {
            Animator animator = playerMain.GetComponent<Animator>();
            CameraMove cameraMove = playerMain.GetComponent<CameraMove>();
            PlayerMovementWZeroGravity playerMovement = playerMain.GetComponent<PlayerMovementWZeroGravity>();

            if (animator != null) animator.enabled = true;
            if (cameraMove != null) cameraMove.enabled = true;
            if (playerMovement != null) playerMovement.enabled = true;
        }
        else
        {
            Debug.LogWarning("playerMain n�o est� atribu�do.");
        }

        isMovementDisabled = false; // Atualiza o estado para habilitado
    }
}
