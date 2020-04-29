using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject playerCube;

    public Slider slider;

    void Update()
    {
        SetHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = playerCube.GetComponent<StatSheet>().CON;
        slider.value = playerCube.GetComponent<StatSheet>().CON;
    }

    public void SetHealth()
    {
        slider.value = playerCube.GetComponent<StatSheet>().CON;
    }
}
