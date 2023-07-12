using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingSlider : MonoBehaviour
{
    [SerializeField]
    Text text_Value;
    [SerializeField]
    Slider slider;

    public void OnValueChanged_Slider()
    {
        text_Value.text = $"{(int)(slider.value * 100)}";
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }

    public float GetValue()
    {
        return slider.value;
    }
}
