using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ObjectManager3 : ObjectManager
{
    public GameObject smallClock;
    public GameObject madlen;
    public GameObject[] curtains;
    public GameObject shine;
    public GameObject beanStalk;

    bool robeClickFirst = true;
    bool beanClickFirst = true;

    bool waterOnSoil = false;
    bool beanOnSoil = false;
    bool timeOn = false;
    bool curtainOpen = false;

    public enum State
    {
        StartAct, NormalAct, EventAct, GrowAct
    }
    public State state;

    void Awake()
    {
        Initialize();
        state = State.StartAct;
    }

    float currentTime = 0f;

    void Update()
    {
        if(waterOnSoil && beanOnSoil && timeOn && curtainOpen)
        {
            beanStalk.SetActive(true);
            currentTime += Time.deltaTime;
            if (currentTime > 2.0f)
            {
                state = State.GrowAct;
                currentTime = 0f;
                waterOnSoil = false; beanOnSoil = false; timeOn = false; curtainOpen = false;
            }
        }

        if(state== State.GrowAct)
        {
            if (currentTime > 2.0f)
            {
                state = State.NormalAct;
                currentTime = 0f;
            }
        }

        if (state == State.StartAct)
        {
            ShowingTalkalogue(7);
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
            if (!Testmoving.Instance.isAlreadyTalking || InventoryManager.Instance.isMouseCarryingObj)
            {
                switch (hit.collider.gameObject.name)
                {
                    case "Sink":
                        if(InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "컵")
                        {
                            DeleteInventory("컵");
                            AddInventory("물이든컵");
                        }
                        break;
                    case "Door":
                        ShowingDialogue(21);
                        break;
                    case "Robe":
                        if (robeClickFirst)
                        {
                            AddInventory("태엽");
                            ShowingDialogue(22);
                            robeClickFirst = false;
                        }
                        break;
                    case "Bean":
                        AddInventory("강낭콩");
                        hit.collider.gameObject.SetActive(false);
                        if (beanClickFirst)
                        {
                            ShowingDialogue(23);
                            beanClickFirst = false;
                        }
                        break;
                    case "Bean2":
                        AddInventory("강낭콩");
                        hit.collider.gameObject.SetActive(false);
                        if (beanClickFirst)
                        {
                            ShowingDialogue(23);
                            beanClickFirst = false;
                        }
                        break;
                    case "Diary":
                        ShowingDialogue(24);
                        break;
                    case "Handle":
                        ShowingDialogue(25);
                        break;
                    case "FakePlant":
                        if(InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "물이든컵")
                        {
                            waterOnSoil = true;
                            DeleteInventory("물이든컵");
                        }
                        else if(InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "강낭콩")
                        {
                            beanOnSoil = true;
                            DeleteInventory("강낭콩");
                        }
                        else
                        {
                            ShowingDialogue(26);
                        }
                        break;
                    case "Knife":
                        ShowingDialogue(27);
                        break;
                    case "Doma":
                        ShowingDialogue(28);
                        break;
                    case "Drawer":
                        ShowingDialogue(29);
                        break;
                    case "SmallClock":
                        if (InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "태엽")
                        {
                            DeleteInventory("태엽");
                            timeOn = true;
                        }
                        else
                        {
                            ShowingDialogue(30);
                        }
                        break;
                    case "Madlen":
                        ShowingDialogue(31);
                        AddInventory("마들렌반죽");
                        madlen.SetActive(false);
                        break;
                    case "Chair":
                        ShowingDialogue(32);
                        break;
                    case "Oven":
                        ShowingDialogue(33);
                        //두개임 나중에처리
                        break;
                    case "BeanPlant":
                        ShowingDialogue(35);
                        break;
                    case "Fridge":
                        if (hit.collider.gameObject.GetComponent<Image>().sprite.name == "Fridge_Close")
                        {
                            hit.collider.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Fridge_Open");
                            smallClock.SetActive(true);
                            madlen.SetActive(true);
                        }

                        break;
                    case "Rabbit":
                        ShowingTalkalogue(8);
                        state = State.EventAct;
                        break;
                    case "Cup":
                        AddInventory("컵");
                        hit.collider.gameObject.SetActive(false);
                        break;
                    case "Curtain":
                        curtains[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Curtain_Open");
                        curtains[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Curtain_Open");
                        curtainOpen = true;
                        shine.SetActive(true);
                        break;
                    case "BeanStalk":
                        missionIsComplete = true;
                        break;
                }
            }
            PutBackInventory();

        }
        TextFade();
        MoveScene(4);
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