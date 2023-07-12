using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refrigerator : MyObjects
{
    bool first = true;
    public override void Execute()
    {
        if (first)
        {
            Debug.Log("케익을 선택하세요");
        }
        Debug.Log("냉장고입니다");
    }
}
