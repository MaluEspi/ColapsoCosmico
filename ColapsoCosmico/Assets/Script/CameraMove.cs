using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform cameraMove;

    private Vector2 lookInput;

    float xRotate = 0f;

    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        mouseX = lookInput.x * sensitivity * Time.deltaTime;
        mouseY = lookInput.y * sensitivity * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -80f, 80f);


        cameraMove.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
       
        transform.Rotate(Vector3.up * mouseX);
    }

    
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}
