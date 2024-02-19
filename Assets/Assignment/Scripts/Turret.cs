using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Vector2 target;
    public GameObject missile;
    public Transform spawn;
    float timer;

    void Start()
    {
        timer = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        target = (Vector2)GameObject.Find("plane").transform.position;
        transform.up = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(missile, spawn.position, spawn.rotation);
            timer = Random.Range(2,5);
        }
    }
}
