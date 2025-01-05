using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskControllerEnergy : MonoBehaviour
{
    public int maxAttempts = 3; // N�mero m�ximo de tentativas
    public int currentAttempts; // Tentativas atuais
    public GameObject[] wires; // Array de fios
    public int correctWireIndex; // �ndice do fio correto

    public GameObject lightsRed; // Luzes vermelhas que devem ser desativadas
    public Vector3 respawn; // Ponto de respawn

    public GameObject finishedTask;

    void Start()
    {
        currentAttempts = maxAttempts;
        correctWireIndex = Random.Range(0, wires.Length); // Escolhe aleatoriamente o fio correto
        Debug.Log("Fio correto: " + correctWireIndex); // Para fins de depura��o
    }

    public void CutWire(int wireIndex)
    {
        if (wireIndex == correctWireIndex)
        {
            Debug.Log("Voc� cortou o fio correto!");
            currentAttempts = 0; // Define tentativas para 0, pois o jogador cortou o fio correto
            lightsRed.SetActive(false); // Desativa as luzes vermelhas
            wires[wireIndex].SetActive(false); // Desativa o fio cortado
            finishedTask.SetActive(false);
        }
        else
        {
            currentAttempts--;
            Debug.Log("Voc� cortou o fio errado! Tentativas restantes: " + currentAttempts);
            wires[wireIndex].SetActive(false); // Desativa o fio cortado

            if (currentAttempts == 0)
            {
                Die();
               
            }
        }
    }

    void Die()
    {
        currentAttempts = maxAttempts; // Reinicia as tentativas
        Debug.Log("Voc� morreu!"); 
        transform.position = respawn; // Respawn no ponto definido
    }
}
