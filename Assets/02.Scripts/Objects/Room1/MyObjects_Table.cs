using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjects_Table : MyObjects
{
    private bool first = true;

    public override void Execute()
    {
        if (first)
        {
            flag += (int)Check.Table;
            first = false;
        }
        Debug.Log("서랍장입니다.");
    }
}
