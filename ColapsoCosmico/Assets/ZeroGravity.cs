using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    private CharacterController characterController;
    public bool isInZeroGravityZone = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
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
        // Verifica se o objeto que saiu do trigger é o jogador
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
        // Se o jogador estiver na zona de gravidade zero, aplique uma força para simular flutuação
        if (isInZeroGravityZone && characterController != null)
        {
            // Aplica uma força para cima para simular flutuação
            Vector3 upwardForce = Vector3.up * 1000f; // Ajuste o valor conforme necessário
            characterController.Move(upwardForce * Time.deltaTime);
        }
    }
}
