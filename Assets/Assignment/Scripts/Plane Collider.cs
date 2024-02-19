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
    int lerpCount = 2;

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
        if (collision.gameObject.tag == "missile enemy" && GameObject.Find("plane").GetComponent<Mover>().health > 0)
        {
            if (lerpCount > 0)
            {
                lerpTimer = 0;
            }
            //lerpCount exists to constrain the Lerp color animation to only play two times. This prevents the death effect from
            //flashing red like the first two hits of damage.
            lerpCount--;
            SendMessage("takeDamage");
        }
    }

}
