using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Vector2 target;
    Rigidbody2D rb;
    public float speed = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Sets the missile's target to the plane's position at the TIME OF THE MISSILE SPAWNING. This is intentional,
        //to ensure the missile fires in a straight line and can be dodged rather than homing in on the player.
        target = (Vector2)GameObject.Find("plane").transform.position - rb.position;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + target * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ensures missile can only be destroyed by colliding with the player.
        if (collision.gameObject.tag == "plane")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
