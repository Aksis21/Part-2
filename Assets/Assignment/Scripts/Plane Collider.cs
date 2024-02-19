using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollider : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float lerpTimer = 0;
    SpriteRenderer sr;
    public Color startcol;
    public Color endcol;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        lerpTimer = 1;
    }

    void Update()
    {
        float interpolation = animationCurve.Evaluate(lerpTimer);
        lerpTimer += Time.deltaTime;
        sr.color = Color.Lerp(startcol, endcol, interpolation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "missile")
        lerpTimer = 0;
        SendMessage("takeDamage");
    }

}
