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
    public int health = 3;
    public Slider slider;
    public GameObject scoreCounter;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //Ensures health bar always starts at full.
        slider.value = 3;
    }

    private void FixedUpdate()
    {
        //Prevents player from moving if dead.
        if (health <= 0) return;

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
        if (health <= 0) return;

        //sets destination to mouse position. Will be used in multiple places later on.
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //following 2 lines set rotation of plane to always point towards the mouse position.
        rotator = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        transform.right = rotator;

        //Player fires whenever main mouse button is pressed
        if (Input.GetMouseButtonDown(0) && health > 0)
        {
            animator.SetTrigger("Firing");
        }
    }

    //Function performs all necessary tasks when plane takes damage.
    void takeDamage()
    {
        //Player loses 1 hp (3 max) when function is called.
        health--;

        //Player loses 1 score when they take damage.
        scoreCounter.GetComponent<ScoreCounter>().scoreCount--;

        //Updates healthbar to match.
        slider.value = health;

        //Updates from base state to "damage 1" state in animator.
        if (health == 2)
        {
            animator.SetBool("Damage 1", true);
        }

        //Updates from "damage 1" state to "damage 2" state in animator.
        if (health == 1)
        {
            animator.SetBool("Damage 2", true);
        }

        //Updates from "damage 2" state to "dead" state in animator.
        if (health == 0)
        {
            animator.SetBool("Dead", true);
        }
    }
}
