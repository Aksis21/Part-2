using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    public Color selectedCol;
    public Color unselectedCol;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    //You gave me fred. You did this.
    public void selected(bool fred)
    {
        if (fred)
        {
            sr.color = selectedCol;
        }
        else
        {
            sr.color = unselectedCol;
        }
    }
}
