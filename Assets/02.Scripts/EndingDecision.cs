using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDecision : MonoBehaviour
{
    //엔딩은 총 5가지이며 엔딩을 결정하는 요소는 토끼와의 유대, 현실에 대한 미련이 있다.
    //토끼와의 유대 갈림은 3개, 현실에 대한 미련 갈림은 6개이다.

    public static EndingDecision Instance = null;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public int realityFavor = 0; //현실에 대한 미련
    public int rabbitFavor = 0; //토끼와의 유대
    public bool hesitate = false; //망설인다

    public bool endingFlag = false; //게임종료
    
    void Update()
    {
        if (endingFlag)
        {
            ChooseEnding();
        }
    }

    void ChooseEnding()
    {
        if ((realityFavor >= 5 && realityFavor <=6) && (rabbitFavor >= 0 && rabbitFavor <= 1)) //현실에 대한 미련 5~6, 토끼와의 유대 0~1
        {
            Ending(1); 
        }
        else if ((realityFavor >= 5 && realityFavor <= 6) && (rabbitFavor >= 2 && rabbitFavor <= 3)) //현실에 대한 미련 5~6, 토끼와의 유대 2~3
        {
            Ending(2); 
        }
        else if (realityFavor == 4) //현실에 대한 미련 4, 토끼와의 유대 상관없음
        {
            Ending(3); 
        }
        else if (realityFavor >= 0 && realityFavor <= 3) //현실에 대한 미련 0~3, 토끼유대 상관없음
        {
            Ending(4); 
        }
    }

    void Ending(int i)
    {
        if(i <= 3 && hesitate) //엔딩 1,2,3의 갈림길에서 망설였다면
        {
            i = 5; //5번째 엔딩으로 전환
        }

        switch (i)
        {
            case 1:
                //엔딩1. 수많은 꿈중 하나
                return;
            case 2:
                //엔딩2. 애착인형
                return;
            case 3:
                //엔딩3. 허물어진 경계
                return;
            case 4:
                //엔딩4. 내일보다 행복한 꿈
                return;
            case 5:
                //엔딩5. 상관없음, 엔딩 1~3 보기 진전에만 갈 수 있는 엔딩
                return;
        }
    }
}
