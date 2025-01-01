using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teste : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.81f;
    public float zeroGravityForce = 0.2f; // Força de flutuação na gravidade zero

    private Vector2 movementInput;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isInZeroGravityZone = false; // Para controlar a zona de gravidade zero
     private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        isGrounded = controller.isGrounded;

        // Se o jogador estiver na zona de gravidade zero
        if (isInZeroGravityZone)
        {
            // Aplica a força de flutuação
            velocity.y = zeroGravityForce; // Ajuste a força conforme necessário
        }
        else
        {
            // Lógica normal de gravidade
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime; // Aplica a gravidade
        }

        // Movimento do jogador
        Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Sala"))
        {
            isInZeroGravityZone = true; // Ativa a gravidade zero
            Debug.Log("Entrou na zona de gravidade zero"); // Mensagem de depuração
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu do trigger é o jogador
        if (other.CompareTag("Sala"))
        {
           // isInZeroGravityZone = false; // Desativa a gravidade zero
            Debug.Log("Saiu da zona de gravidade zero"); // Mensagem de depuração
        }
    }
}
