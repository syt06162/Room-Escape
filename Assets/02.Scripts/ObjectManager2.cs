using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ObjectManager2 : ObjectManager
{
    public bool[] clickFirst = new bool[4];
    public bool sirenFirstClick = false;
    
    bool startCloseUp = false;

    public GameObject player;
    public Testmoving testmoving;
    public Transform eventPoint;
    public GameObject closeUpFirst;
    public GameObject closeUpSecond;
    public GameObject notCloseUps;

    public GameObject fridgeClose;
    public GameObject fridgeOpen;
    public GameObject fridgeHollow;

    public GameObject screen;
    
    public enum State
    {
        StartAct, NormalAct, EventActOne, EventActTwo, SirenAct, NineTalk
    }
    public State state;

    void Awake()
    {
        Initialize();
        closeUpFirst.SetActive(false);
        closeUpSecond.SetActive(false);
        backBtn.SetActive(false);
        state = State.StartAct;
    }
   
    float currentTime = 0f;

    void Update()
    {
        if (state == State.StartAct) //시작대사
        {
            testmoving.sr.flipX = player.transform.position.x < eventPoint.position.x;
            //testmoving.sr.flipX = true;
            ShowingTalkalogue(0);
        }
        else if(state == State.EventActOne){ //걸어가는 스테이트
            player.GetComponent<Animator>().SetBool("Walking", true);
            player.transform.position = Vector2.MoveTowards(player.transform.position, eventPoint.position, 0.05f);
            testmoving.sr.flipX = true;
            if(Vector2.Distance(player.transform.position, eventPoint.position) < 0.1f)
            {
                player.GetComponent<Animator>().SetBool("Walking", false);
                Testmoving.Instance.isAlreadyTalking = false;
                state = State.EventActTwo;
            }
        }
        else if (state == State.EventActTwo) //클로즈업 화면1
        {
            testmoving.sr.flipX = true;
            closeUpFirst.SetActive(true);
            notCloseUps.SetActive(false);
        }

        if(state == State.SirenAct)
        {
            currentTime += Time.deltaTime;
            if(currentTime < 1.0f)
            {
                screen.GetComponent<Image>().sprite = Resources.Load<Sprite>("GalaxyDanger");
            }
            if (currentTime > 1.0f)
            {
                ShowingTalkalogue(1);
            }
        }


        if (state == State.NormalAct || state == State.EventActTwo || state == State.SirenAct || state == State.NineTalk)
        {
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
                        case "Screen":
                            if (!sirenFirstClick)
                            {
                                ShowingDialogue(8);
                            }
                            else if(state == State.NineTalk)
                            {
                                ShowingTalkalogue(3);
                            }
                            break;
                        case "Controller":
                            ShowingDialogue(9);
                            break;
                        case "CarrotCake":
                            ShowingDialogue(10);
                            clickFirst[1] = true;
                            break;
                        case "CheeseCake":
                            ShowingDialogue(11);
                            break;
                        case "Dish":
                            ShowingDialogue(12);
                            break;
                        case "Door":
                            if(InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "열쇠")
                            {
                                SceneManager.LoadScene(3);
                            }
                            else
                            {
                                ShowingDialogue(13);
                            }
                            break;
                        case "RabbitEatingCarrotCake":
                            ShowingDialogue(15);
                            clickFirst[2] = true;
                            break;
                        case "CarrotCake2":
                            ShowingDialogue(16);
                            break;
                        case "MoonSurface":
                            ShowingDialogue(16);
                            break;
                        case "SleepingRabbit":
                            ShowingDialogue(18);
                            clickFirst[3] = true;
                            break;
                        case "SulraejabgiRabbit":
                            ShowingDialogue(19);
                            break;
                        case "HungryRabbit":
                            if(sirenFirstClick && InventoryManager.Instance.isMouseCarryingObj && InventoryManager.carryObj.GetComponent<Image>().sprite.name == "당근케이크조각")
                            {
                                DeleteInventory("당근케이크조각");
                                AddInventory("열쇠");
                            }
                            else {
                                ShowingDialogue(20);
                            }
                            break;
                        case "RefrigeratorClose":
                            fridgeClose.SetActive(false);
                            fridgeOpen.SetActive(true);
                            break;
                        case "RefrigeratorOpen":
                            fridgeOpen.SetActive(false);
                            fridgeHollow.SetActive(true);
                            AddInventory("당근케이크조각");
                            break;
                        case "RefrigeratorHollow":
                            break;
                        case "Window":
                            if(state == State.NormalAct)
                            {
                                closeUpSecond.SetActive(true);
                                backBtn.SetActive(true);
                                notCloseUps.SetActive(false);
                            }
                            break;
                        case "Surface":
                            ShowingDialogue(17);
                            clickFirst[0] = true;
                            break;
                        case "Rabbit":
                            if (InventoryManager.Instance.isMouseCarryingObj)
                            {
                                ShowingTalkalogue(6);
                            }
                            else if (sirenFirstClick)
                            {
                                ShowingTalkalogue(2);
                            }
                            break;
                    }
                    
                }
                PutBackInventory();
            }
        }
        TextFade();
        MoveScene(3);
    }

    public void NextDialogue()
    {
        if(state == State.NormalAct || state == State.EventActTwo)
        {
            if (SimpleCSVParser.Instance.dialogues[currentRowNum].dialogue[dialoguepage + 1] == null) //나가기
            {
                if (!sirenFirstClick && currentRowNum == 9)
                {
                    print("about to sir...");
                    state = State.SirenAct;
                    sirenFirstClick = true;
                }
                
                Testmoving.Instance.isAlreadyTalking = false;
                dialoguepage = 0;
                currentRowNum = 0;
                dialogueText.text = "";
                bottomPanel.SetActive(false);
                
                if (IsAllMissionComplete(clickFirst) && state == State.EventActTwo)
                {
                    state = State.NormalAct;
                    closeUpFirst.SetActive(false);
                    notCloseUps.SetActive(true);
                }
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
                if (!startCloseUp)
                {
                    state = State.EventActOne;
                    startCloseUp = true;
                }
                else if (state == State.SirenAct)
                {
                    state = State.NineTalk;
                    screen.GetComponent<Image>().sprite = Resources.Load<Sprite>("GalaxyNine");

                }
                else if (state == State.NineTalk)
                {
                    if(currentRowNum == 3)
                    {
                        Testmoving.Instance.isAlreadyTalking = true;
                        nineAnswer.SetActive(true);
                    }
                    else
                    {
                        screen.GetComponent<Image>().sprite = Resources.Load<Sprite>("GalaxyRed");
                        state = State.NormalAct;
                    }
                }
                else
                {
                    state = State.NormalAct;
                }
                dialoguepage = 0;
                currentRowNum = 0;
                dialogueText.text = "";
                bottomPanel.SetActive(false);
                Testmoving.Instance.isAlreadyTalking = false;

            }
            else
            {
                dialoguepage++;
                ShowingTalkalogue(currentRowNum);
            }
        }
    }
    
    public void BackBtn()
    {
        closeUpFirst.SetActive(false);
        closeUpSecond.SetActive(false);
        backBtn.SetActive(false);
        notCloseUps.SetActive(true);
    }

    public void NineAnswer(bool right)
    {
        nineAnswer.SetActive(false);
        if (right)
        {
            ShowingTalkalogue(5);

        }
        else{
            ShowingTalkalogue(4);
        }
    }
    
}