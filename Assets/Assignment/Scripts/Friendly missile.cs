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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + target * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
