using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager1 : MonoBehaviour
{
    public int turretsDestroyed = 0;
    public float timer = 2;

    private void Update()
    {
        if (turretsDestroyed >= 5)
        {
            timer -= Time.deltaTime;
        }

        if (GameObject.Find("plane").GetComponent<Mover>().health <= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            loadNextScene();
        }
    }

    void loadNextScene()
    {

    }
}
