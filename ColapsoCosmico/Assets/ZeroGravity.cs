using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    private CharacterController characterController;
    public bool isInZeroGravityZone = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger � o jogador
        if (other.CompareTag("Player"))
        {
            characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                isInZeroGravityZone = true;
                // Desativa a gravidade manualmente
               // characterController.enabled = false; // Desabilita o CharacterController
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do trigger � o jogador
        if (other.CompareTag("Player"))
        {
            if (characterController != null)
            {
                isInZeroGravityZone = false;
                // Reativa a gravidade manualmente
             //   characterController.enabled = true; // Reabilita o CharacterController
            }
        }
    }

    private void Update()
    {
        // Se o jogador estiver na zona de gravidade zero, aplique uma for�a para simular flutua��o
        if (isInZeroGravityZone && characterController != null)
        {
            // Aplica uma for�a para cima para simular flutua��o
            Vector3 upwardForce = Vector3.up * 1000f; // Ajuste o valor conforme necess�rio
            characterController.Move(upwardForce * Time.deltaTime);
        }
    }
}
