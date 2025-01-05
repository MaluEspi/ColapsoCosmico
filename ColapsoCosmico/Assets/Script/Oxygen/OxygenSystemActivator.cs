using UnityEngine;

public class OxygenSystemActivator : MonoBehaviour
{
    public GameObject[] requiredItems; 
    public GameObject systemFixedObject; 
    public float interactionDistance = 3f;

    private bool allItemsDestroyed = false;

    void Update()
    {
        if (!allItemsDestroyed)
        {
            CheckRequiredItems(); 
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction(); 
        }
    }

    void CheckRequiredItems()
    {
        foreach (GameObject item in requiredItems)
        {
            if (item != null)
            {
                return; 
            }
        }

        allItemsDestroyed = true;
    }

    void CheckInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject == gameObject)
            {
                systemFixedObject.SetActive(true); 
            }
        }
    }
}
