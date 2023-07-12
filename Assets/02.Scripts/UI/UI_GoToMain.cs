using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GoToMain : MonoBehaviour
{
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnClick_GoToMainYes()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClick_GoToMainNo()
    {
        SetActive(false);
    }
}
