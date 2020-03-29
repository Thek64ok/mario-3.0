using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HMSBarScript : MonoBehaviour
{
    public Slider slider;
    private Knight_HealthSystem hSystem;

    void Start()
    {
        hSystem = FindObjectOfType<Knight_HealthSystem>();
    }
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetCurrentValue(float value)
    {
        slider.value = value;
    }
    public void AddHMS(float value)
    {
        hSystem.knightCurrentHealth += value;
    }
}
