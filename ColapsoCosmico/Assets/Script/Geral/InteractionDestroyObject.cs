using UnityEngine;

public class InteractionDestroyObject : MonoBehaviour
{
    public float interactionDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }
    }

    void CheckInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject == gameObject)
            {
                Destroy(hitObject); 
            }
        }
    }
}
