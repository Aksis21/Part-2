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

        //Stores the "scoreCount" variable into a local int to be used below - not really necessary, just tidies
        //up the lower code a bit.
        yourScore = GameObject.Find("Score Count").GetComponent<ScoreCounter>().scoreCount;

        //When all 5 turrets are destroyed, begins the countdown to the menu scene loading.
        if (turretsDestroyed >= 5)
        {
            timer -= Time.deltaTime;
        }

        //When the plane is destroyed, begins countdown to menu scene loading.
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
        //Updates the currentScore pref to the player's final score at the end of the game.
        PlayerPrefs.SetInt("currentScore", yourScore);

        //If the player's score was greater than the recorded high score, updates it to the player's score.
        if (yourScore > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", yourScore);
        }
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
}
