using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; //맵이 이동, 플레이어가 시작될 위치
    private Testmoving thePlayer;
    void Start()
    {

        thePlayer = FindObjectOfType<Testmoving>();

        if (startPoint == thePlayer.currentMapName)
        {
            thePlayer.transform.position = this.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
