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
        
        foreach (GameObject obj in targetObjects)
        {
            if (obj != null && !obj.activeSelf) 
            {
                deactivatedCount++;   
                obj.SetActive(false); 
            }
        }

        
        if (deactivatedCount >= 5)
        {
            LoadWinnerScene(); 
        }
    }

    void LoadWinnerScene()
    {
        SceneManager.LoadScene("Winner");
    }
}
