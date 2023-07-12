using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSize : MonoBehaviour
{
    public GameObject leftBtn;
    public GameObject rightBtn;
    public GameObject objCanv;

    public GameObject[] spaces;
    public int currentSpace = 0; //몇번째 공간인지

    public GameObject player;
    public Transform leftpoint;
    public Transform rightpoint;

    //public static bool isCloseUping = false;

    private void Awake()
    {
        if(spaces.Length <= 1 || spaces == null) //공간의 개수가 하나라면
        {
            leftBtn.SetActive(false);
            rightBtn.SetActive(false);
        }
        else
        {
            currentSpace = spaces.Length; //현재 몇번째 공간인지 위치 저장
            SetActiveSpace(currentSpace);
            rightBtn.SetActive(false); //가장 오른쪽 공간이기 때문에 오른쪽 화살표를 비활성화 시킨다

        }
        objCanv = GameObject.Find("ObjectCanvas");
        player = GameObject.Find("Player");
    }

    public void MoveRoom(bool left)
    {
        if (left)
        {
            currentSpace--; //위치 몇번째인지 업데이트
            SetActiveSpace(currentSpace);
            if (currentSpace <= 1) //제일 왼쪽 끝 공간이면
            {
                leftBtn.SetActive(false); //왼쪽으로 가는 버튼 비활성화
            }
            rightBtn.SetActive(true);
            player.transform.position = rightpoint.position;
        }
        else
        {
            currentSpace++; //위치 몇번째인지 업데이트
            SetActiveSpace(currentSpace);
            if (currentSpace >= spaces.Length) //제일 오른쪽 끝 공간이면
            {
                rightBtn.SetActive(false); //오른쪽으로 가는 버튼 비활성화
            }
            leftBtn.SetActive(true);
            player.transform.position = leftpoint.position;
        }
    }

    void SetActiveSpace(int num)
    {
        for(int i=0; i<spaces.Length; i++)
        {
            spaces[i].SetActive(false);
        }
        spaces[num - 1].SetActive(true);
    }

}
