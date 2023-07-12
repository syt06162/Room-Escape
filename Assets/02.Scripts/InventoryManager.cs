using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance = null;

    public GameObject inventoryUI;
    public GameObject inventoryLayout;

    public bool isMouseCarryingObj = false;
    public static GameObject carryObj;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        carryObj = GameObject.Find("CarryObj");
        carryObj.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void ClickInventory(int num)
    {
        if(inventoryLayout.transform.GetChild(num - 1).GetComponent<Image>().sprite.name != "InputFieldBackground")
        {
            inventoryUI.SetActive(false);
            isMouseCarryingObj = true;
            carryObj.SetActive(true);
            carryObj.GetComponent<Image>().sprite = inventoryLayout.transform.GetChild(num - 1).GetComponent<Image>().sprite;
        }
        else
        {
            print("Pressed Inventory is Empty");
        }
    }
}
