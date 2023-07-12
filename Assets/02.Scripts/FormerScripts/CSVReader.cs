using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    TextAsset dialogueCSV;

    void Start()
    {
        dialogueCSV = Resources.Load<TextAsset>("ScriptExample");

        string[] lineData = dialogueCSV.text.Split(new char[] { '\n' }); //엔터로 줄 분리
        print(lineData[0]);

        //for (int i = 1; i < lineData.Length - 1; i++) //첫줄 막줄 무시
        //{
        //    string[] row = lineData[i].Split(','); //쉼표로 칸 분리

        //}
    }
}
