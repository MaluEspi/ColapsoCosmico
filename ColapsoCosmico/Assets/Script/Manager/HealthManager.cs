using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public Slider healthBar;
    public int maxLives = 4; 
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives; 
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentLives -= damage; 
        UpdateHealthBar();

        if (currentLives <= 0)
        {
            GameOver(); 
        }
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentLives / maxLives; 
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
