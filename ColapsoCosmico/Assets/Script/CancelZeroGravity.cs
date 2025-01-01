using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelZeroGravity : MonoBehaviour
{
    public LayerMask interactableLayer;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // 0 � o bot�o esquerdo do mouse
        {
            CancelGravityZero();
        }
    }

    private void CancelGravityZero()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, interactableLayer))
        {
            // Verifica se o objeto atingido tem a tag "Interactable"
            if (hit.collider.CompareTag("Interactable"))
            {
                // Obt�m o script PlayerMovement do jogador
                PlayerMovementWZeroGravity playerMovement = FindObjectOfType<PlayerMovementWZeroGravity>();
                if (playerMovement != null)
                {
                    playerMovement.isInZeroGravityZone = false; // Desativa a gravidade zero
                    Debug.Log("Gravidade zero cancelada ao clicar no objeto: " + hit.collider.name); // Mensagem de depura��o
                }
            }
        }
    }
}
