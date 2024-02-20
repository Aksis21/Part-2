using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    public int turretsDestroyed = 0;
    public float timer = 2;
    int currentSceneIndex;
    int yourScore;

    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        yourScore = GameObject.Find("Score Count").GetComponent<ScoreCounter>().scoreCount;

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
        PlayerPrefs.SetInt("currentScore", yourScore);
        if (yourScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", yourScore);
        }
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
}
