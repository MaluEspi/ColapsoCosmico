using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public GameObject playerMain;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Player"))
        {
            playerMain.GetComponent<PlayerMovementWZeroGravity>().enabled = true;
            playerMain.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
