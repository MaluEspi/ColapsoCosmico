using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    #region Singleton
    public static AsteroidManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public GameObject[] asteroidPrefabs;
    public float asteroidSpawnDistance = 50f;
    public float spawnTime = 2f;

    public Camera targetCamera; 
    public float centralSpawnRadius = 5f; 
    private float timer = 0f;

    void Start()
    {
        timer = spawnTime;

        if (targetCamera == null)
        {
            Debug.LogError("Camera não encotrada");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            SpawnNewAsteroid();
            timer = 0f;
        }
    }

    private void SpawnNewAsteroid()
    {
        if (targetCamera == null) return;

        float camDistance = asteroidSpawnDistance; 
        Vector3 bottomLeft = targetCamera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector3 topRight = targetCamera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        float minX = bottomLeft.x;
        float maxX = topRight.x;
        float minY = bottomLeft.y;
        float maxY = topRight.y;

        Vector3 screenCenter = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, bottomLeft.z);

        Vector3 spawnPos;
        int attempts = 0;

        do
        {
            float newX = Random.Range(minX, maxX);
            float newY = Random.Range(minY, maxY);
            spawnPos = new Vector3(newX, newY, bottomLeft.z);

            float distanceFromCenter = Vector3.Distance(new Vector3(newX, newY, 0), new Vector3(screenCenter.x, screenCenter.y, 0));

            if (distanceFromCenter <= centralSpawnRadius || attempts > 3) break;

            attempts++;

        } while (true);

        Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], spawnPos, Quaternion.identity);
    }
}
