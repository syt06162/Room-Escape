using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름
    private Testmoving thePlayer; // movingObject의 맵네임을 받아오기 위해서

    private bool flag;

    public Transform target; // 한 씬에서 맵 이동
    void Start()
    {
        thePlayer = FindObjectOfType<Testmoving>(); //하이어라키에 있는 모든객체의 <>컴포넌트를 검색해 리턴 - GetComponent는 해당 스크립트가 적용된것만 리턴
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0f;

            RaycastHit2D hit = Physics2D.Raycast(targetPos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Point")          
                {

                    thePlayer.currentMapName = transferMapName;
                    SceneManager.LoadScene(transferMapName);
                }
            }
        }
    }
}


    

