using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.81f;

    private Vector2 movementInput;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private Animator anim;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;
        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
       
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    // isso aqui e para "travar" a movimentacao do player enquanto eu estiver mexendo com os paineis de energia
    public void CancelMove(bool value)
    {
        canMove = value;
    }

}
