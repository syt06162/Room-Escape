using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_ItemButton : MonoBehaviour
{
    [SerializeField]
    UI_Inventory ui_Inventory;

    void Start()

    {
        ui_Inventory?.SetActive(false);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnClick_Inventory()
    {
        ui_Inventory?.SetActive(true);
    }

}
