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

    bool canMouseMove = true;

    // Start is called before the first frame update
    void Start()
    {
       //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMouseMove)
        {
            mouseX = lookInput.x * sensitivity * Time.deltaTime;
            mouseY = lookInput.y * sensitivity * Time.deltaTime;

            xRotate -= mouseY;
            xRotate = Mathf.Clamp(xRotate, -80f, 80f);


            cameraMove.localRotation = Quaternion.Euler(xRotate, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);

        }
    }
    
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    public void CancelCamera(bool value)
    {
        canMouseMove = value;
    }
    /* ao inves de mexer nesse script, acho que dava para colocar essa funcao no script do objeto, que quando ele entra em contato o script da camera
     * é desativado e a camera trava em uma posicao especifica, pq dai vc consegue mexer no mouse e a camera ta travado onde tu quer acho que fica melhro a interacao e nao da bug*/
    // te falar q oq ta dando mais problema e a animaçao de idle do player pq ai ele nao fica 100% parado=, vou ver o eu faco
}
