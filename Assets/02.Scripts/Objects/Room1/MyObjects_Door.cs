using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyObjects_Door : MyObjects
{
    private bool first = true;
    
    public override void Execute()
    {
        if (first)
        {
            flag += (int)Check.Door;
            first = false;
        }
        Debug.Log("문입니다.");
    }
}
