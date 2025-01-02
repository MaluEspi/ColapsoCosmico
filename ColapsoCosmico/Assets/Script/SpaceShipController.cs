using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public Camera targetCamera;

    public float moveSpeed = 10f;
    public float maxRotation = 25f;

    private Rigidbody rb;
    private float minX, maxX, minY, maxY;

    public GameObject missilePrefab; 
    public Transform missileLaunchPoint; 
    public float missileCooldown = 1.5f; 

    private float lastMissileTime = 0f; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetUpBoundries();
    }

    void Update()
    {
        MoveShip();
        RotateShip();

        CalculateBoundries();
        HandleMissileLaunch();
    }

    private void RotateShip()
    {

        float offsetX = transform.position.x - ((minX + maxX) / 2); 
        float rangeX = (maxX - minX) / 2; 
        float newRotationZ;

        if (offsetX < 0)
        {
            newRotationZ = Mathf.Lerp(0f, -maxRotation, Mathf.InverseLerp(0f, -rangeX, offsetX));
        }
        else
        {
            newRotationZ = Mathf.Lerp(0f, maxRotation, Mathf.InverseLerp(0f, rangeX, offsetX));
        }

        Vector3 currentRotationVector3 = new Vector3(0f, 0f, newRotationZ);
        Quaternion newRotation = Quaternion.Euler(currentRotationVector3);
        transform.localRotation = newRotation;
    }

    private void CalculateBoundries()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        transform.position = currentPosition;
    }

    private void SetUpBoundries()
    {
        float camDistance = Vector3.Distance(transform.position, targetCamera.transform.position);
        Vector2 bottomCorners = targetCamera.ViewportToWorldPoint(new Vector3(0f, 0f, camDistance));
        Vector2 topCorners = targetCamera.ViewportToWorldPoint(new Vector3(1f, 1f, camDistance));

        Bounds gameObjectBounds = GetComponent<Collider>().bounds;
        float objectWidth = gameObjectBounds.size.x;
        float objectHeight = gameObjectBounds.size.y;

        minX = bottomCorners.x + objectWidth;
        maxX = topCorners.x - objectWidth;

        minY = bottomCorners.y + objectHeight;
        maxY = topCorners.y - objectHeight;
    }

    private void MoveShip()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontalMovement, verticalMovement, 0f);

        rb.velocity = movementVector * moveSpeed;
    }
    private void HandleMissileLaunch()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastMissileTime + missileCooldown)
        {
            LaunchMissile();
            lastMissileTime = Time.time; 
        }
    }

    private void LaunchMissile()
    {
        if (missilePrefab == null || missileLaunchPoint == null)
        {
            Debug.LogWarning("MissilePrefab ou MissileLaunchPoint não configurado no SpaceShipController.");
            return;
        }

        Quaternion missileRotation = Quaternion.Euler(90f, 0f, 0f);
        Instantiate(missilePrefab, missileLaunchPoint.position, missileRotation);
    }
}
