using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ObjectManager1 : ObjectManager
{
    public bool[] clickFirst = new bool[8];
    public GameObject x;
    bool gameConsoleClickFirst = true;

    public enum State
    {
        StartAct, NormalAct, EventAct
    }
    public State state;

    void Awake()
    {
        Initialize();
        state = State.NormalAct;
    }

    void Update()
    {
        if(state == State.StartAct)
        {
            //ShowingTalkalogue(0);
        }
        else if(state == State.NormalAct) {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
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
                        case "Door":
                            ShowingDialogue(0);
                            CheckFirstTrial(0);
                            break;
                        case "Book":
                            ShowingDialogue(5);
                            CheckFirstTrial(5);
                            break;
                        case "BookCase":
                            CheckFirstTrial(4);
                            ShowingDialogue(4);
                            break;
                        case "Bed":
                            CheckFirstTrial(1);
                            ShowingDialogue(1);
                            break;
                        case "Table":
                            ShowingDialogue(3);
                            CheckFirstTrial(3);
                            break;
                        case "GameConsole":
                            if (gameConsoleClickFirst)
                            {
                                ShowingDialogue(7);
                                gameConsoleClickFirst = false;
                            }
                            else
                            {
                                PlayGame();
                            }
                            CheckFirstTrial(7);
                            break;
                        case "Badge":
                            ShowingDialogue(6);
                            CheckFirstTrial(6);
                            break;
                        case "Rabbit":
                            ShowingDialogue(2);
                            CheckFirstTrial(2);
                            break;
                    }
                }
            }
        }
        TextFade();
        MoveScene(2);
    }
    
    void CheckFirstTrial(int num)
    {
        if (!clickFirst[num])
        {
            clickFirst[num] = true;
            x.transform.GetChild(num).GetComponent<Image>().color = Color.grey;
        }
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

                if (IsAllMissionComplete(clickFirst))
                {
                    missionIsComplete = true;
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
                Testmoving.Instance.isAlreadyTalking = false;
                dialoguepage = 0;
                currentRowNum = 0;
                dialogueText.text = "";
                bottomPanel.SetActive(false);
            }
            else
            {
                dialoguepage++;
                ShowingTalkalogue(currentRowNum);
            }
        }
    }

    void PlayGame()
    {
        print("Play Game");
        SceneManager.LoadScene("Shooting");
    }
}