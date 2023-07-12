using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public GameObject bottomPanel;
    public GameObject nineAnswer;
    public Text dialogueText;
    public Image speakerImage;
    public GameObject backBtn;
    public GameObject inventoryAddText;
    public GameObject inventoryDeleteText;
    public GameObject inventoryLayout;

    public int inventoryObjects = 0;

    protected bool missionIsComplete = false;

    protected Camera cam;
    public GameObject blackOut;
    Color cola = new Color(0, 0, 0, 0);
    Color colb = new Color(0, 0, 0, 255);

    protected void Initialize()
    {
        print("Initialize Inheritance");
        bottomPanel.SetActive(false);
        //nineAnswer.SetActive(false);
        blackOut.SetActive(false);
        inventoryAddText.SetActive(false);
        inventoryDeleteText.SetActive(false);

        cam = Camera.main;
    }

    float currentAddTime = 0f;
    float currentDeleteTime = 0f;

    protected void TextFade()
    {
        if (inventoryAddText.activeSelf)
        {
            currentAddTime += Time.deltaTime;
            if (currentAddTime > 1.0f)
            {
                inventoryAddText.SetActive(false);
                currentAddTime = 0f;
            }
        }
        if (inventoryDeleteText.activeSelf)
        {
            currentDeleteTime += Time.deltaTime;
            if (currentDeleteTime > 1.0f)
            {
                inventoryDeleteText.SetActive(false);
                currentDeleteTime = 0f;
            }
        }
    }

    public int dialoguepage = 0; //줄 내에서 몇번째 대사인지
    public int currentRowNum = 0; //몇번째 줄인지

    public void ShowingDialogue(int num)
    {
        if (InventoryManager.Instance.isMouseCarryingObj)
        {
            return;
        }
        bottomPanel.SetActive(true);
        Testmoving.Instance.isAlreadyTalking = true;
        speakerImage.sprite = Resources.Load<Sprite>("주인공");
        dialogueText.text = SimpleCSVParser.Instance.dialogues[num].dialogue[dialoguepage];
        currentRowNum = num; //현재 줄을 기억
    }

    public void ShowingTalkalogue(int num)
    {
        if (InventoryManager.Instance.isMouseCarryingObj)
        {
            return;
        }
        bottomPanel.SetActive(true);
        Testmoving.Instance.isAlreadyTalking = true;
        dialogueText.text = SimpleCSVParser.Instance.talkalogues[num].talkalogue[dialoguepage];
        speakerImage.sprite = Resources.Load<Sprite>(SimpleCSVParser.Instance.talkalogues[num].speaker[dialoguepage]);
        currentRowNum = num; //현재 줄을 기억
    }

    public void IsTalking(bool isTalking)
    {
        Testmoving.Instance.isAlreadyTalking = isTalking;
    }

    protected void AddInventory(string obj)
    {
        print("Added " + obj + " to Inventory");
        inventoryAddText.SetActive(true);
        inventoryAddText.GetComponent<Text>().text = obj + "을(를) 획득했습니다.";
        inventoryObjects++;
        inventoryLayout.transform.GetChild(inventoryObjects - 1).GetComponent<Image>().sprite = Resources.Load<Sprite>(obj);
    }

    protected void DeleteInventory(string obj)
    {
        print(obj + "Lost");
        inventoryDeleteText.SetActive(true);
        inventoryDeleteText.GetComponent<Text>().text = obj + "을(를) 잃었습니다.";

        for (int i = FindInInventory(obj); i < 9; i++)
        {
            inventoryLayout.transform.GetChild(i).GetComponent<Image>().sprite = inventoryLayout.transform.GetChild(i + 1).GetComponent<Image>().sprite;
        }
        PutBackInventory();
        inventoryObjects--;
    }

    protected int FindInInventory(string obj)
    {
        int num = 0;
        for (int i = 0; i < 10; i++)
        {
            if (inventoryLayout.transform.GetChild(i).GetComponent<Image>().sprite.name == obj)
            {
                num = i;
                break;
            }
        }
        return num;
    }

    public void PutBackInventory()
    {
        if (InventoryManager.Instance.isMouseCarryingObj)
        {
            InventoryManager.Instance.isMouseCarryingObj = false;
            InventoryManager.carryObj.GetComponent<Image>().sprite = null;
            InventoryManager.carryObj.SetActive(false);
            Testmoving.Instance.isAlreadyTalking = false;
        }
    }

    float t = Mathf.Clamp(0, 0, 255);
    protected void MoveScene()
    {
        if (missionIsComplete)
        {
            print(t);
            print("MoveScene activated");
            blackOut.SetActive(true);
            blackOut.GetComponent<Image>().color = Color.Lerp(cola, colb, t);
            t += Time.deltaTime * 0.05f;
            if (t > 0.2f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                t = 0;
            }
        }
    }
    protected void MoveScene(int scene)
    {
        if (missionIsComplete)
        {
            print(t);
            print("MoveScene activated");
            blackOut.SetActive(true);
            blackOut.GetComponent<Image>().color = Color.Lerp(cola, colb, t);
            t += Time.deltaTime * 0.05f;
            if (t > 0.2f)
            {
                SceneManager.LoadScene(scene);
                t = 0;
            }
        }
    }

    protected bool IsAllMissionComplete(bool[] thingsToClick)
    {
        for (int i = 0; i < thingsToClick.Length; i++)
        {
            if (thingsToClick[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
