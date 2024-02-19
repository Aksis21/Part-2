using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFire : MonoBehaviour
{
    public GameObject missile;
    public Transform spawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(missile, spawn.position, spawn.rotation);
        }
    }
}
