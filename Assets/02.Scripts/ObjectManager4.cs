using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ObjectManager4 : ObjectManager
{
    bool broochClickFirst = true;

    public GameObject chestClose;
    public GameObject chestOpen;
    public GameObject chestHollow;

    bool scareCrowOne = false;
    bool scareCrowTwo = false;
    bool scareCrowThree = false;

    public GameObject[] ravens;

    public enum State
    {
        StartAct, NormalAct, EventAct
    }
    public State state;

    void Awake()
    {
        base.Initialize();
        state = State.StartAct;
    }
    
    float currentTime = 0f;

    void Update()
    {
        if (state == State.StartAct)
        {
            ShowingTalkalogue(12);
        }
        
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (InventoryManager.Instance.isMouseCarryingObj && hit.point != null)
        {
            InventoryManager.carryObj.transform.position = hit.point;
        }
        if (Input.GetMouseButtonDown(0) && hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Box"))
            {
                print("GameObject " + hit.collider.gameObject + " clicked");
            }
            if (!Testmoving.Instance.isAlreadyTalking)
            {
                switch (hit.collider.gameObject.name)
                {
                    case "Entrance":
                        ShowingDialogue(37);
                        break;
                    case "RabbitBab":
                        ShowingDialogue(38);
                        break;
                    case "Butterfly":
                        ShowingDialogue(39);
                        break;
                    case "RoseBrooch":
                        AddInventory("장미브로치");
                        hit.collider.gameObject.SetActive(false);
                        if (broochClickFirst)
                        {
                            ShowingDialogue(40);
                            broochClickFirst = false;
                        }
                        break;
                    case "WhiteRoseTree":
                        ShowingDialogue(41);
                        break;
                    case "Paint":
                        ShowingDialogue(42);
                        break;
                    case "Board":
                        ShowingDialogue(43);
                        break;
                    case "Soil":
                        ShowingDialogue(44);
                        break;
                    case "Wheat":
                        ShowingDialogue(45);
                        break;
                    case "Exit":
                        ShowingDialogue(46);
                        break;
                    case "ChestClose":
                        chestClose.SetActive(false);
                        chestOpen.SetActive(true);
                        break;
                    case "ChestOpen":
                        chestOpen.SetActive(false);
                        chestHollow.SetActive(true);
                        AddInventory("삽");
                        break;
                    case "Clover":
                        hit.collider.gameObject.SetActive(false);
                        AddInventory("네잎클로버");
                        break;
                    case "Scarecrow":
                        if (!scareCrowOne && !scareCrowTwo && !scareCrowThree)
                        {
                            ShowingTalkalogue(15);
                        }
                        else if (scareCrowOne && !scareCrowTwo && !scareCrowThree)
                        {
                            ShowingTalkalogue(16);
                        }
                        else if (scareCrowOne && scareCrowTwo && !scareCrowThree)
                        {
                            ShowingTalkalogue(17);
                        }
                        else if (scareCrowOne && scareCrowTwo && scareCrowThree)
                        {
                            ShowingTalkalogue(18);
                        }
                        break;
                    case "Bread":
                        AddInventory("빵");
                        hit.collider.gameObject.SetActive(false);
                        break;
                    case "Raven1":
                        if (InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "빵")
                        {
                            ravens[0].SetActive(false);
                            ravens[1].SetActive(false);
                            scareCrowOne = true;
                        }
                        break;
                    case "Raven2":
                        if (InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "빵")
                        {
                            ravens[0].SetActive(false);
                            ravens[1].SetActive(false);
                            scareCrowOne = true;
                        }
                        break;
                    case "WateringPot":
                        AddInventory("물뿌리개");
                        hit.collider.gameObject.SetActive(false);
                        if (InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "Sudo")
                        {

                        }
                        break;
                    case "Sudo":
                        AddInventory("수도꼭지");
                        hit.collider.gameObject.SetActive(false);
                        if (InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "수도꼭지")
                        {

                        }
                        break;
                }
            }
            PutBackInventory();
        }
        TextFade();
        MoveScene(5);
    }

    public void NextDialogue()
    {
        if (state == State.NormalAct)
        {
            if (SimpleCSVParser.Instance.dialogues[currentRowNum].dialogue[dialoguepage + 1] == null) //나가기
            {
                Testmoving.Instance.isAlreadyTalking = false;
                dialoguepage = 0;
                currentRowNum = 0;
                dialogueText.text = "";
                bottomPanel.SetActive(false);
            }
            else
            {
                dialoguepage++;
                ShowingDialogue(currentRowNum);
            }
        }
        else
        {
            if (SimpleCSVParser.Instance.talkalogues[currentRowNum].talkalogue[dialoguepage + 1] == null) //currentRowNum은 유지된다. 어차피 한줄 내에서 해결되기 때문
            {
                Testmoving.Instance.isAlreadyTalking = false;
                dialoguepage = 0;
                currentRowNum = 0;
                dialogueText.text = "";
                bottomPanel.SetActive(false);
                state = State.NormalAct;
            }
            else
            {
                dialoguepage++;
                ShowingTalkalogue(currentRowNum);
            }
        }
    }
    
}