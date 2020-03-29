using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HMSBarScript : MonoBehaviour
{
    public Slider slider;
    private Knight_HealthSystem sys;

    void Start()
    {
        sys = FindObjectOfType<Knight_HealthSystem>();
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
    public void AddHP(float value)
    {
        sys.knightCurrentHealth += value;
    }
    public void AddMP(float value)
    {
        sys.knightCurrentMana += value;
    }
    public void AddSP(float value)
    {
        sys.knightCurrentStamina += value;
    }
}
