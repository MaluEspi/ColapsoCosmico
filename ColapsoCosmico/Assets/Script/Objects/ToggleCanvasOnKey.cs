using UnityEngine;
using UnityEngine.UI;

public class ToggleCanvasOnKey : MonoBehaviour
{
    public GameObject canvasToToggle;

    private bool isCanvasActive = false;

    void Start()
    {
        if (canvasToToggle != null)
        {
            canvasToToggle.SetActive(false);
        }
    }

    void Update()
    {
        if (Camera.main == null)
        {
            return; // Sai do m�todo se a c�mera n�o estiver dispon�vel
        }
        if (Input.GetKeyDown(KeyCode.E) && IsMouseOver())
        {
            ToggleCanvas();
        }
    }
    private void ToggleCanvas()
    {
        if (canvasToToggle != null)
        {
            isCanvasActive = !isCanvasActive;
            canvasToToggle.SetActive(isCanvasActive);
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