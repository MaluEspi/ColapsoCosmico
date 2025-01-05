using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.81f;

    public Transform pointA;
    public Transform pointB; 

    private Vector2 movementInput;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Animator anim;
    private Camera playerCamera;

    private bool isAnimating = true; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerCamera = Camera.main;

        controller.enabled = false; 
        playerCamera.transform.position = pointB.position; 
        playerCamera.transform.rotation = pointB.rotation; 

        Invoke(nameof(EndAnimation), 7.37f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating) return;

        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void EndAnimation()
    {
        isAnimating = false; 

        playerCamera.transform.position = pointA.position;
        playerCamera.transform.rotation = pointA.rotation;

        controller.enabled = true;
    }
}
