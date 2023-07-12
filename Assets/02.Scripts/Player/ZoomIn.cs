using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{

    private float ZoomRatio = 0.3f;
    private int flag = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flag += 1;
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0f;

            RaycastHit2D hit = Physics2D.Raycast(targetPos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "interactable")
                {
                    Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
                    Camera.main.orthographicSize *= ZoomRatio;

                }

            }
        }


        if (flag == 2)
        {
            Camera.main.transform.position = new Vector3(0, 0, -10);
            Camera.main.orthographicSize = 5;
            flag = 0;

        }
       


    }
}
