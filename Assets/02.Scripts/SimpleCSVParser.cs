using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCSVParser : MonoBehaviour
{
    //Dialogue : 오브젝트 대사 (1)씬 (2)오브젝트넘버 (3)오브젝트이름 (4)대사배열
    //Talkalogue : 화자 간의 대사 (1)씬 (2)ID (3)화자배열 (4)대사배열

    public static SimpleCSVParser Instance = null;
    TextAsset dialogueCSV;
    TextAsset talkalogueCSV;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public List<Talkalogue> talkalogues = new List<Talkalogue>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    
    void Start()
    {
        dialogueCSV = Resources.Load<TextAsset>("KoreanObjectScript");
        if(dialogueCSV == null)
        {
            print("DialogueCSV is null");
            return;
        }
        else
        {
            print("DialogueCSV exists");
        }

        string[] lineData = dialogueCSV.text.Split(new char[] { '\n' }); //엔터로 줄 분리
        for (int i = 1; i < lineData.Length - 1; i++) //첫줄 막줄 무시
        {
            string[] row = lineData[i].Split(new char[] { ',' }); //쉼표로 칸 분리
            Dialogue dial = new Dialogue();
            int.TryParse(row[0], out dial.scene);
            int.TryParse(row[1], out dial.id);
            dial.objName = row[2];

            string[] dialogueData = row[3].Split(new char[] { '+' }); //+로 대사분리
            for (int j=0; j<dialogueData.Length; j++)
            {
                dial.dialogue[j] = dialogueData[j];
                //print(dial.dialogue[j]);
            }
            
            dialogues.Add(dial);
            
        }
        //foreach (Dialogue dial in dialogues){print(dial.scene + " " + dial.id +" " + dial.objName + " " + dial.dialogue);}
        
        talkalogueCSV = Resources.Load<TextAsset>("KoreanDialogueScript");
        if (talkalogueCSV == null)
        {
            print("TalkalogueCSV is null");
            return;
        }
        else
        {
            print("TalkalogueCSV exists");
        }
        
        string[] lineData2 = talkalogueCSV.text.Split(new char[] { '\n' }); //엔터로 줄 분리
        
        int sameIDChecker = 0;
        int insideNum = 0;
        for (int i = 1; i < lineData2.Length - 1; i++) //첫줄 막줄 무시
        {
            string[] row = lineData2[i].Split(new char[] { ',' }); //쉼표로 칸 분리
            //여기까지 딱 한줄에서 마디마디 나뉘어진 상태. 0번째 로우는 씬넘버를, 1번째 로우는 id를, 2번째 로우는 스피커를, 3번째 로우는 대사를 담고 있음
            //이 2번째 로우와 3번째 로우를 ID마다 모아서 배열로 저장해줄거임.

            int idCheck; //실제로 두번째 칸에 적혀 있는 아이디 받아오기
            int.TryParse(row[1], out idCheck);

            if(sameIDChecker != idCheck || row[1] == null) //전줄의 ID와 이번줄의 ID가 다르다면 (첫줄의 경우도 포함.)
            {
                Talkalogue talk = new Talkalogue();
                int.TryParse(row[0], out talk.scene);
                int.TryParse(row[1], out talk.id);
                insideNum = 0;
                talk.speaker[insideNum] = row[2];
                talk.talkalogue[insideNum] = row[3];
                talkalogues.Add(talk);
                sameIDChecker++;
                insideNum++;
            }
            else //전줄의 id와 이번줄의 id가 같다면
            {
                talkalogues[idCheck - 1].speaker[insideNum] = row[2];
                talkalogues[idCheck - 1].talkalogue[insideNum] = row[3];
                insideNum++;
            }
        }
    }
    
}
