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
        currentScore.text = PlayerPrefs.GetInt("currentScore").ToString();
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void resetScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
    }
}
