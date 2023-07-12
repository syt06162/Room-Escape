using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager_Main : MonoBehaviour
{
    public static UIManager_Main Instance { get; private set; } = null;

    [SerializeField]
    UI_Settings ui_Settings;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Init();
        }
    }

    private void Init()
    {
        ui_Settings?.SetActive(false);
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClick_Load()
    {
        SceneManager.LoadScene("Load");
    }

    public void OnClick_Settings()
    {
        ui_Settings?.SetActive(true);
    }

    public void OnClick_Chapter()
    {
        
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

}
