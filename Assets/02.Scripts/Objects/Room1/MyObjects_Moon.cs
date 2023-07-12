using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjects_Moon : MyObjects
{
    private bool first = true;

    public override void Execute()
    {
        if (first)
        {
           flag +=(int)Check.Moon;
            first = false;
        }
        Debug.Log("창문입니다.");

        Camera.main.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
        Camera.main.transform.position.z);
        Camera.main.orthographicSize *= ZoomRatio;

        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.transform.position = new Vector3(0, 0, -10);
            Camera.main.orthographicSize = 5;
        }
    }
}
