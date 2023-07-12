using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Settings : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField]
    UI_SettingSlider slider_BGM;
    [SerializeField]
    UI_SettingSlider slider_SFX;

    public void SetActive(bool value)
    {
        if (value)
        {
            slider_BGM.SetValue(0.5f);
            slider_SFX.SetValue(0.5f);
        }
        gameObject.SetActive(value);
    }

    public void OnClick_SettingsExit()
    {
        SetActive(false);
    }
}