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

    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = PlayerPrefs.GetInt("currentScore").ToString();
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
