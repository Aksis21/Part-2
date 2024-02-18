using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    Vector2 rotator;
    Rigidbody2D rb;
    public float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    private void Update()
    {
        //sets destination to mouse position. Will be used in multiple places later on.
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //following 2 lines set rotation of plane to always point towards the mouse position.
        rotator = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        transform.right = rotator;

        if (Input.GetMouseButtonDown(1))
        {
            
        }
    }
}
