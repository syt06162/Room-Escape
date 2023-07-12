using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Load : MonoBehaviour
{
    public static UI_Load Instance { get; private set; } = null;

    [SerializeField]
    UI_Load ui_Load;

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
        ui_Load?.SetActive(false);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnClick_LoadExit()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_LoadFirst()
    {

    }

    public void OnClick_LoadSecond()
    {

    }

    public void OnClick_LoadThird()
    {

    }

    public void OnClick_Up()
    {
        SetActive(false);
        ui_Load?.SetActive(true);
    }

    public void OnClick_Down()
    {
        SetActive(false);
        ui_Load?.SetActive(true);
    }
}
