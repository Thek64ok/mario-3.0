using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HMSBarScript : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetCurrentValue(float value)
    {
        slider.value = value;
    }
}
