using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject plane;
    float timer;
    public float spawnRate = 1f;
    float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += spawnRate * Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            spawnTime = Random.Range(1, 5);
            Instantiate(plane);
        }
    }
}
