using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text gameOverText;
    public float startTimeInMinutes = 10f;

    private float currentTime; 
    //private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTimeInMinutes * 60; 
        gameOverText.gameObject.SetActive(false); 
        StartCoroutine(TimerCountdown());
    }

    IEnumerator TimerCountdown()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
            yield return null;
        }

        TriggerGameOver();
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerGameOver()
    {
        //isGameOver = true;
        SceneManager.LoadScene("GamerOver");
        timerText.text = "00:00"; 
    }
}
