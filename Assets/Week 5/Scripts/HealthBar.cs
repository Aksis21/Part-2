using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealthBar(float HP)
    {
        slider.value = 0 + HP;
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
}
