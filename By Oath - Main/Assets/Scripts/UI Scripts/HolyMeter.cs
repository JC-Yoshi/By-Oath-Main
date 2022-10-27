using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolyMeter : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxWater(int amoCount)
    {
        {
            slider.maxValue = amoCount;
            slider.value = amoCount;

            fill.color = gradient.Evaluate(1f);
        }
    }

    public void SetWater(int amoCount)
    {
        {
            slider.value = amoCount;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

}

