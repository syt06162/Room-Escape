using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameFourth : MonoBehaviour
{
    public static UI_InGameFourth Instance { get; private set; } = null;

    [SerializeField]
    UI_InGameFourth ui_InGameFourthOne;
    [SerializeField]
    UI_InGameFourth ui_InGameFourthTwo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
        }
    }

    private void Init()
    {
        ui_InGameFourthOne?.SetActive(false);
        ui_InGameFourthTwo?.SetActive(false);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }


    public void OnClick_Left()
    {
        SetActive(false);
        ui_InGameFourthOne?.SetActive(true);
    }

    public void OnClick_Right()
    {
        SetActive(false);
        ui_InGameFourthTwo?.SetActive(true);
    }
}
