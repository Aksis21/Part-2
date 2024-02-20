using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    public int scoreCount;

    void Start()
    {
        //Always starts the player's score at 0 when beginning the game. Externally, this integer will be
        //updated multiple times in each game.
        scoreCount = 0;
    }

    void Update()
    {
        //Displays the current score in the bottom-left of the game screen.
        scoreText.text = scoreCount.ToString();
    }
}
