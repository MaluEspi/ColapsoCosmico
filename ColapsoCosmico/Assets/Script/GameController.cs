using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] targetObjects;
    private int deactivatedCount = 0;

    void Update()
    {
        deactivatedCount = 0; // Resetar o contador a cada atualiza��o

        foreach (GameObject obj in targetObjects)
        {
            if (obj != null && !obj.activeSelf)
            {
                deactivatedCount++;
            }
        }

        // Verifica se todos os 5 itens est�o desativados
        if (deactivatedCount >= targetObjects.Length) // Verifica se todos os objetos est�o desativados
        {
            LoadWinnerScene();
        }
    }

    void LoadWinnerScene()
    {
        SceneManager.LoadScene("Winner");
    }
}
