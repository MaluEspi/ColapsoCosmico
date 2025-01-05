using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class OxygenManager : MonoBehaviour
{
    public Slider oxygenSlider;
    public float oxygenDuration = 120f;
    public GameObject systemFixedObject;
    public float interactionDistance = 2.5f;

    private float currentOxygen;
    private bool isPlutoniumActive = false;
    private bool isSystemFixed = false;
    private GameObject currentInteractable;

    void Start()
    {
        currentOxygen = oxygenDuration;
        oxygenSlider.maxValue = oxygenDuration;
        oxygenSlider.value = currentOxygen;
    }

    void Update()
    {
        if (isSystemFixed)
            return;

        float reductionRate = isPlutoniumActive ? 2f : 1f;
        currentOxygen -= Time.deltaTime * reductionRate;

        if (currentOxygen <= 0)
        {
            currentOxygen = 0;
            GameOver(); // Chama o método para carregar a cena "GameOver"
        }

        oxygenSlider.value = currentOxygen;

        if (systemFixedObject.activeInHierarchy)
        {
            isSystemFixed = true;
            oxygenSlider.gameObject.SetActive(false);
        }

        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            InteractWithObject(currentInteractable);
        }
    }

    void CheckInteraction()
    {
        currentInteractable = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Oxygen") || hitObject.CompareTag("Plutonium") || hitObject.CompareTag("Remedy"))
            {
                currentInteractable = hitObject;
            }
        }
    }

    void InteractWithObject(GameObject interactable)
    {
        if (interactable.CompareTag("Oxygen"))
        {
            currentOxygen += 60f;
            if (currentOxygen > oxygenDuration)
                currentOxygen = oxygenDuration;
        }
        else if (interactable.CompareTag("Plutonium"))
        {
            isPlutoniumActive = true;
        }
        else if (interactable.CompareTag("Remedy"))
        {
            isPlutoniumActive = false;
        }

        Destroy(interactable);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver"); // Carrega a cena "GameOver"
    }
}
