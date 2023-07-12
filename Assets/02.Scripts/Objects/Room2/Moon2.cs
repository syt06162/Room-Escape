using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon2 : MyObjects
{
    public override void Execute()
    {
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
