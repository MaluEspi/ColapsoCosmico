using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelZeroGravity : MonoBehaviour
{
    public LayerMask interactableLayer;
    public GameObject buttonOff;
    public GameObject doorOne;
    public GameObject doorTwo;
    public GameObject downwardBar;
    public GameObject zeroGravityFloor;

    public GameObject playerMain;
    public GameObject finishedTask;
    void Start()
    {
        // Inicialização, se necessário
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CancelGravityZero();
        }
    }

    private void CancelGravityZero()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, 100f, interactableLayer))
        {
            Debug.Log("Raycast funcionou, atingiu: " + hit.collider.name);
            // Verifica se o objeto atingido tem a tag "Interactable"
            if (hit.collider.CompareTag("Interactable"))
            {

                // Obtém o script PlayerMovement do jogador
                PlayerMovementWZeroGravity playerMovement = FindObjectOfType<PlayerMovementWZeroGravity>();
                if (playerMovement != null)
                {
                    playerMovement.isInZeroGravityZone = false; // Desativa a gravidade zero

                    buttonOff.SetActive(true);
                    doorOne.SetActive(false);
                    doorTwo.SetActive(false);
                    downwardBar.SetActive(false);
                    zeroGravityFloor.SetActive(false);
                    DesableFloatingBox();

                    finishedTask.SetActive(false);
                    playerMain.GetComponent<PlayerMovementWZeroGravity>().enabled = false;
                    playerMain.GetComponent<PlayerMovement>().enabled = true;
                }
            
            }
           
        }
       
    }

    private void DesableFloatingBox()
    {
        Box[] allMyBoxes = FindObjectsOfType<Box>();

        // Desativa cada um dos scripts encontrados
        foreach (Box script in allMyBoxes)
        {
            script.enabled = false; // Desativa o script
            Debug.Log("Desativado: " + script.gameObject.name); // Mensagem de depuração
        }
    }
}
