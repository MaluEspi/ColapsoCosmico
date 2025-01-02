using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f; 
    public float lifeTime = 5f; 

    void Start()
    {
        Destroy(gameObject, lifeTime); 
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
