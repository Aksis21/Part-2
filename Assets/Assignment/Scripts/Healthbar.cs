using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset = new Vector3(-20, 50, 0);

    void Update()
    {
        //sets Healthbar to follow the player, but moved slightly according to the offset so as to make sure the player is visible
        transform.position = (Camera.main.WorldToScreenPoint(plane.transform.position) + offset);
    }
}
