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
        deactivatedCount = 0; // Resetar o contador a cada atualização

        foreach (GameObject obj in targetObjects)
        {
            if (obj != null && !obj.activeSelf)
            {
                deactivatedCount++;
            }
        }

        // Verifica se todos os 5 itens estão desativados
        if (deactivatedCount >= targetObjects.Length) // Verifica se todos os objetos estão desativados
        {
            LoadWinnerScene();
        }
    }

    void LoadWinnerScene()
    {
        SceneManager.LoadScene("Winner");
    }
}
