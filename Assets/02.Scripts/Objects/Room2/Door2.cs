using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MyObjects
{
    bool first = true;
    public override void Execute()
    {
        if (first)
        {
            Debug.Log("문2 처음 클릭시");
            first = false;
        }
        Debug.Log("문2 입니다.");
    }
}
