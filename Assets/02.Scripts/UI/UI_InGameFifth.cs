using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameFifth : MonoBehaviour
{
    public static UI_InGameFifth Instance { get; private set; } = null;

    [SerializeField]
    UI_InGameFifth ui_InGameFifth;

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
        ui_InGameFifth?.SetActive(false);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }


    public void OnClick_Left()
    {
        SetActive(false);
        ui_InGameFifth?.SetActive(true);
    }

    public void OnClick_Right()
    {
        SetActive(false);
        ui_InGameFifth?.SetActive(true);
    }
}
