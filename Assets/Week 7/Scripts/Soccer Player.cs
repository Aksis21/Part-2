using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 500;
    public Color selectedCol;
    public Color unselectedCol;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
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

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
