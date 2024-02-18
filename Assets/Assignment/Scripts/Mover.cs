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
    Animator animator;
    public int damageTaken = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (damageTaken >= 3) return;

        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    private void Update()
    {
        /*Player is dead after taking 3 hits. This ensures that death effects/animations do not update position/rotation or
        allow player to keep firing after death.*/
        if (damageTaken >= 3) return;

        //sets destination to mouse position. Will be used in multiple places later on.
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //following 2 lines set rotation of plane to always point towards the mouse position.
        rotator = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        transform.right = rotator;

        //Player fires whenever main mouse button is pressed
        if (Input.GetMouseButtonDown(0) && damageTaken < 3)
        {
            animator.SetTrigger("Firing");
        }

        //PLACEHOLDER - TAKE DAMAGE ON RIGHT MOUSE BUTTON
        if (Input.GetMouseButtonDown(1))
        {
            damageTaken++;
        }

        if (damageTaken == 1)
        {
            animator.SetBool("Damage 1", true);
        }

        if (damageTaken == 2)
        {
            animator.SetBool("Damage 2", true);
        }

        if (damageTaken == 3)
        {
            animator.SetBool("Dead", true);
        }
    }
}
