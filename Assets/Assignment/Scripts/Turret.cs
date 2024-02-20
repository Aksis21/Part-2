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
    float health = 3;
    public GameObject scoreCounter;

    void Start()
    {
        timer = Random.Range(2, 5);
    }

    void Update()
    {
        //Sets the Turret's target to always be the plane's position.
        target = (Vector2)GameObject.Find("plane").transform.position;

        //Rotates Turret towards player.
        transform.up = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        timer -= Time.deltaTime;
        
        //Spawns missile when timer reaches zero, then resets timer.
        if (timer <= 0)
        {
            Instantiate(missile, spawn.position, spawn.rotation);
            timer = Random.Range(2,5);
        }

        //Destroys Turret once health reaches zero. Sends message to increase score by 1, updates scene manager's
        //tracker (once 5 turrets are destroyed, that function will end the game scene).
        if (health <= 0)
        {
            scoreCounter.GetComponent<ScoreCounter>().scoreCount++;
            GameObject.Find("SceneManager").GetComponent<SceneManager1>().turretsDestroyed++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If hit only by a missile fired from the plane, the Turret takes 1 damage (each turret has 3 HP).
        if (collision.gameObject.tag == "missile friend")
        {
            health--;
        }
    }
}
