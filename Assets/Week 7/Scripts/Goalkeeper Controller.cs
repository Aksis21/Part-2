using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalie;
    Vector2 direction;
    Vector2 distanceFromGoal;
    public float distance;
    public float goalRad;

    // Update is called once per frame
    void Update()
    {
        if (Controller.selectedPlayer == null) return;

        direction = (Vector2)transform.position - (Vector2)Controller.selectedPlayer.transform.position;
        distance = direction.magnitude;
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        if (distance/2 < goalRad)
        {
            goalie.position = (Vector2)transform.position - direction * (distance/2);
        }
        else
        {
            goalie.position = (Vector2)transform.position - direction * goalRad;
        }
    }
}
