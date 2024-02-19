using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFire : MonoBehaviour
{
    public GameObject missile;
    public GameObject plane;
    public Transform spawn;

    // Update is called once per frame
    void Update()
    {
        //Fires on mouse down only while player has health. Once player health reaches zero (and is destroyed), they can no longer fire.
        if (Input.GetMouseButtonDown(0) && plane.GetComponent<Mover>().health > 0)
        {
            Instantiate(missile, spawn.position, spawn.rotation);
        }
    }
}
