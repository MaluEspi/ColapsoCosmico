using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyTaskController : MonoBehaviour
{
    public int maxAttempts = 3; // Número máximo de tentativas
    private int currentAttempts; // Tentativas atuais
    public GameObject[] wires; // Array de fios
    public int correctWireIndex; // Índice do fio correto

    public GameObject lightsRed;
    public Vector3 respawn;

    void Start()
    {
        currentAttempts = maxAttempts;
        correctWireIndex = Random.Range(0, wires.Length); // Escolhe aleatoriamente o fio correto
        Debug.Log("Fio correto: " + correctWireIndex); // Para fins de depuração
    }

    public void CutWire(int wireIndex)
    {
        if (wireIndex == correctWireIndex)
        {
            Debug.Log("Você cortou o fio correto!");
            // Adicione lógica para o que acontece quando o jogador corta o fio correto
            currentAttempts = 0;
            lightsRed.SetActive(false);
        }
        else
        {
            currentAttempts--;
            Debug.Log("Você cortou o fio errado! Tentativas restantes: " + currentAttempts);
            if (currentAttempts <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        currentAttempts = maxAttempts;
        Debug.Log("Você morreu!");
        transform.position = respawn;

    }
}
