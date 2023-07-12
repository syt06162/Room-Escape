using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameThird : MonoBehaviour
{
    public static UI_InGameThird Instance { get; private set; } = null;

    [SerializeField]
    UI_InGameThird ui_InGameThird;

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
        ui_InGameThird?.SetActive(false);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }


    public void OnClick_Left()
    {
        SetActive(false);
        ui_InGameThird?.SetActive(true);
    }

    public void OnClick_Right()
    {
        SetActive(false);
        ui_InGameThird?.SetActive(true);
    }
}
