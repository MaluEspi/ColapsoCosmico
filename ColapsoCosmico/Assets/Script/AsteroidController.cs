using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float moveSpeed = 20f;

    private Rigidbody rb;
    private Vector3 randomRotation;
    private float removePositionZ;

    private Camera targetCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomRotation = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));

        targetCamera = GameObject.Find("Camera").GetComponent<Camera>();

        if (targetCamera == null)
        {
            Debug.LogError("Camera n�o encontrada");
        }
        else
        {
            removePositionZ = targetCamera.transform.position.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < removePositionZ)
        {
            Destroy(gameObject);
        }

        Vector3 movementVector = new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
        rb.velocity = movementVector;

        transform.Rotate(randomRotation * Time.deltaTime);
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Spaceship"))
        {
            // Reduz a vida do player
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(1); // Dano de 1 vida
            }

            Destroy(gameObject); // Destroi o meteoro
        }
        else if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
