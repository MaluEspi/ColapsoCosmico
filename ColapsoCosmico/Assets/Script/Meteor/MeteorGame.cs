using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeteorGame : MonoBehaviour
{
    public GameObject player; 
    public GameObject meteor; 
    public float interactionDistance = 5f; 
    public LayerMask interactionLayer;
    public GameObject lifeBar;

    private Camera mainCamera;
    private bool canInteract = false;
    private GameObject currentInteractable;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed && canInteract && currentInteractable != null)
        {
            player.SetActive(false);
            meteor.SetActive(true);
            lifeBar.SetActive(true);
        }
    }

    void Update()
    {
        CheckMouseOverObject();
    }

    private void CheckMouseOverObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, interactionLayer))
        {
            currentInteractable = hit.collider.gameObject;

            if (IsWithinDistance(currentInteractable))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
        else
        {
            canInteract = false;
            currentInteractable = null;
        }
    }

    private bool IsWithinDistance(GameObject target)
    {
        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        return distance <= interactionDistance;
    }
}
