using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Transform pointA; // Objeto vazio inicial
    public Transform pointB; // Objeto vazio final
    public float speed = 1f; // Velocidade do movimento
    public float rotationSpeed = 10f; // Velocidade de rotação
    private Transform target; // Destino atual do objeto

    void Start()
    {
        // Inicialmente, o destino é o ponto B
        target = pointB;
    }

    void Update()
    {
        // Movimento suave para o alvo
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Rotação lenta ao longo do eixo Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Verificar se chegou ao destino
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            // Alternar o alvo entre pointA e pointB
            target = target == pointA ? pointB : pointA;
        }
    }


}
