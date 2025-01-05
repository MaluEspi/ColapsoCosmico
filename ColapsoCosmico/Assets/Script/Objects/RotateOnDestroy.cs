using System.Collections;
using UnityEngine;

public class RotateOnDestroy : MonoBehaviour
{
    private bool isDestroyed = false;

    public float rotationSpeed = 50f;

    private float targetRotation = 99f;

    private float currentRotation = 0f;

    public GameObject itemToDestroy;

    void Update()
    {
        if (itemToDestroy == null && !isDestroyed)
        {
            isDestroyed = true;
        }

        if (isDestroyed && Input.GetKeyDown(KeyCode.E) && IsMouseOver())
        {
            StartCoroutine(RotateObject());
        }
    }

    private IEnumerator RotateObject()
    {
        while (currentRotation < targetRotation)
        {
            float step = rotationSpeed * Time.deltaTime;
            currentRotation = Mathf.Min(currentRotation + step, targetRotation);

            transform.rotation = Quaternion.Euler(0, currentRotation, 0);

            yield return null;
        }
    }

    private bool IsMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.transform == transform;
        }

        return false;
    }
}
