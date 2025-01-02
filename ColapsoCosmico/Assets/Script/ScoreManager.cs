using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int targetScore = 6; 
    private int currentScore = 0;
    public GameObject player; 
    public GameObject meteor;
    public GameObject critical;

    public TMP_Text scoreText; 

    void Start()
    {
        UpdateScoreText(); 
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreText();

        if (currentScore >= targetScore)
        {
            WinGame();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }

    private void WinGame()
    {
        Debug.Log("Você venceu!");
        player.SetActive(true);
        meteor.SetActive(false);
        critical.SetActive(false);
        // SceneManager.LoadScene("VictoryScene");
    }
}
