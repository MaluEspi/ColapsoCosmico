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
        if (Camera.main == null)
        {
            Debug.Log("A c�mera principal n�o est� dispon�vel.");
            return; // Sai do m�todo se a c�mera n�o estiver dispon�vel
        }
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
