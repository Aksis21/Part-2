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
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        scoreText.text = scoreCount.ToString();
    }

    void Update()
    {
        scoreText.text = scoreCount.ToString();
    }
}
