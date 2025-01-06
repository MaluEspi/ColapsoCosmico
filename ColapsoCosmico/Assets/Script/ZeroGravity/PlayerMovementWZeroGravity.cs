using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementWZeroGravity : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = -9.81f;

    public float zeroGravityForce = 0.2f;// For�a de flutua��o na gravidade zero
    public float downwardSpeed = 5f;
    public ProgressBar barraDeProgresso; // Refer�ncia � barra de progresso

    private Vector2 movementInput;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    public bool isInZeroGravityZone = false; // Para controlar a zona de gravidade zero
    private Animator anim;

     public GameObject barraProgresso;


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
        if (isInZeroGravityZone )
        {
            speed = 1f;
            // Aplica a for�a de flutua��o
            velocity.y = zeroGravityForce;
            if (Keyboard.current.qKey.isPressed  && barraDeProgresso.barraProgresso.rectTransform.sizeDelta.x > 0)
            {
                // Move o jogador para baixo
                velocity.y -= downwardSpeed * Time.deltaTime;
                barraDeProgresso.DiminuirBarra(barraDeProgresso.larguraOriginal * 0.01f); // Diminui 10% da barra
                StartCoroutine(ReiniciarBarra());
            }
        }
        else
        {
            // L�gica normal de gravidade
            if (isGrounded && velocity.y < 0)
            {
                speed = 4f;
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime;
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
        // Verifica se o objeto que entrou no trigger � o jogador
        if (other.CompareTag("Sala"))
        {
            barraProgresso.SetActive(true);
            isInZeroGravityZone = true; // Ativa a gravidade zero
            Debug.Log("Entrou na zona de gravidade zero");
        }
    }

    private IEnumerator ReiniciarBarra()
    {

        yield return new WaitForSeconds(5f);
        barraDeProgresso.ReiniciarBarra();
    }

}
