using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendlymissile : MonoBehaviour
{
    Vector2 target;
    Rigidbody2D rb;
    public float speed = 50f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Sets the target at the time the missile spawns to the mouse position. While not a perfect solution, this essentially guarantees
        //the player will always fire where they are aiming.
        target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + target * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects if the collision is with the plane. If yes, does not destroy the game object - ensures the projectile can fire without the player
        //accidentally destroying their own projectile.
        if (!(collision.gameObject.tag == "plane"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
