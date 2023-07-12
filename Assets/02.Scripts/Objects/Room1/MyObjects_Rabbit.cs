using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjects_Rabbit : MyObjects
{

    private bool first = true;


    public override void Execute()
    {


        if (first)
        {
            Debug.Log("토끼가 처음이여서");
            flag += (int)Check.Rabbit;
            first = false;

        }
        //저장 스크립트 붙이기
        Debug.Log("토끼입니다");        
    }

}
