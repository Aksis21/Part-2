using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TMP_Text highScore;
    public TMP_Text currentScore;

    private void Update()
    {
        //Sets the displayed text to the value of the held score int's.
        currentScore.text = PlayerPrefs.GetInt("currentScore").ToString();
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void resetScore()
    {
        //When RESET button is pressed, sets the saved High Score int to zero.
        PlayerPrefs.SetInt("highScore", 0);
    }

    public void endGame()
    {
        Application.Quit();
    }
}
