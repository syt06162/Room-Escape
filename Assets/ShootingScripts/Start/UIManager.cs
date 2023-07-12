using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1920, 1080, true);
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }


}
