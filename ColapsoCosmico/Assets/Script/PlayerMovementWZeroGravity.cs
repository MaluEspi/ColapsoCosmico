using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovementWZeroGravity : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = -9.81f;

    public float zeroGravityForce = 0.2f; // Força de flutuação na gravidade zero
    public float downwardSpeed = 5f;

    public Image downwardhBar; // Referência à barra de downward
    public float downward; // Valor atual de downward
    public float maxDownward; // Valor máximo de downward

    //public GameObject downwardBar; // GameObject da barra de downward
    public float attackCost; // Custo de ataque
    public float chargeRate; // Taxa de recarga

    private Coroutine recharge;

    private Vector2 movementInput;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    public bool isInZeroGravityZone = false; // Para controlar a zona de gravidade zero
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        downward = maxDownward; // Inicializa downward com o valor máximo
    }

    void Update()
    {
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

        isGrounded = controller.isGrounded;

        // Se o jogador estiver na zona de gravidade zero
        if (isInZeroGravityZone)
        {
            speed = 1f;
            // Aplica a força de flutuação
            velocity.y = zeroGravityForce;

            if (Keyboard.current.qKey.isPressed && downward > 0)
            {
                // Move o jogador para baixo
                velocity.y -= downwardSpeed * Time.deltaTime;

                // Reduz downward apenas se for maior que zero
                downward -= attackCost;
                if (downward < 0)
                {
                    downward = 0; // Garante que downward não fique negativo
                }
                if (downward == 0)
                {
                    downward = maxDownward;
                }

                downwardhBar.fillAmount = downward / maxDownward; // Atualiza a barra
               // downwardBar.SetActive(true); // Ativa a barra
            }

            // Reinicia a recarga se downward não estiver no máximo
            if (downward < maxDownward)
            {
               
                if (recharge != null)
                {
                    StopCoroutine(recharge);
                }
                recharge = StartCoroutine(RechargeHealth());
            }
        }
        else
        {
            // Lógica normal de gravidade
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
        // Verifica se o objeto que entrou no trigger é a sala
        if (other.CompareTag("Sala"))
        {
           // downwardBar.SetActive(true);
            isInZeroGravityZone = true; // Ativa a gravidade zero
            Debug.Log("Entrou na zona de gravidade zero");
        }
    }

    private IEnumerator RechargeHealth()
    {
        yield return new WaitForSeconds(1f);

        while (downward < maxDownward)
        {
            Debug.Log("recarga");
            downward += chargeRate / 10f; // Aumenta downward
            if (downward > maxDownward)
            {
                downward = maxDownward; // Garante que downward não exceda o máximo
            }
            downwardhBar.fillAmount = downward / maxDownward;
            yield return new WaitForSeconds(.1f);

        }
    }
}
