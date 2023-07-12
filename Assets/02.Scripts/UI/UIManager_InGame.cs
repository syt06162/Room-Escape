using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager_InGame : MonoBehaviour
{
    public static UIManager_InGame Instance { get; private set; } = null;

    public GameObject inventory;

    [SerializeField]
    UI_Settings ui_Settings;
    [SerializeField]
    UI_GoToMain ui_GotoMain;

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
        ui_GotoMain?.SetActive(false);
    }

    public void OnClick_Main()
    {
        ui_GotoMain?.SetActive(true);
    }

    public void OnClick_Settings()
    {
        ui_Settings?.SetActive(true);
    }

    public void BagButton()
    {
        inventory.SetActive(true);
        Testmoving.Instance.isAlreadyTalking = true;
    }

    public void ExitBagButton()
    {
        inventory.SetActive(false);
        Testmoving.Instance.isAlreadyTalking = false;

    }

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    

}
