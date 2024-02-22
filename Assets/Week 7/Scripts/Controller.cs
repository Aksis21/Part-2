using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1f;
    Vector2 direction;
    public static SoccerPlayer selectedPlayer { get; private set; }
    public static void SetSelectedPlayer(SoccerPlayer player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.selected(false);
        }
        selectedPlayer = player;
        player.selected(true);
    }

    void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            selectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = 0;
        }
    }

    void Update()
    {
        if (selectedPlayer == null) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            charge = Mathf.Clamp(charge, 0, maxCharge);
            chargeSlider.value = charge;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedPlayer.transform.position).normalized * charge;
        }
    }
}
