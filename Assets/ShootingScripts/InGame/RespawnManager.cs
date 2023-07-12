using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    float timer = 0;  //
    public GameObject obj_1;
    public GameObject obj_2;
    public GameObject obj_3; //메테오1
    public GameObject obj_4;
    public GameObject obj_5; //보스1
    public GameObject obj_6; //보스2
    public GameObject obj_7; //보스3
    public GameObject obj_8; //마지막 일반몬스터


    public Transform respawnTr;

    public float resTime_1;
    public float resTime_1_dup;
    public float resTime_2;
    public float resTime_2_dup;
    public float resTime_3;
    public float resTime_4;
    public float resTime_4_dup;
    public float resTime_5;

    public float resTime_8;
    public float resTime_8_spd;

    void Start()
    {
        
    }

    // Start is called before the first frame update
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer > 0f) && (timer < 96f))
        {
            if ((timer > 0f) && (timer < 1f))
            {
                StartCoroutine("RespawnEnemy_1");
                timer = 1f;
            }
            if ((timer > 10f) && (timer < 11f))
            {
                StartCoroutine("RespawnEnemy_2");
                timer = 11f;
            }
            if ((timer > 23f) && (timer < 24f))
            {
                StartCoroutine("RespawnEnemy_3");
                timer = 24f;
            }
            if ((timer > 32f) && (timer < 33f))
            {
                StartCoroutine("RespawnEnemy_4");
                StopCoroutine("RespawnEnemy_2");
                timer = 33f;
            }

            if ((timer > 52f) && (timer < 53f)) // 첫번쨰 보스
            {
                Instantiate(obj_5, respawnTr.position + new Vector3(-1, 0, 0), Quaternion.AngleAxis(90f, Vector3.forward));
                StartCoroutine("RespawnEnemy_1_dup");
                StopCoroutine("RespawnEnemy_4");
                timer = 53f;
            } //현 1, 3

            if ((timer > 71f) && (timer < 72f))
            {
                StopCoroutine("RespawnEnemy_3");
                StartCoroutine("RespawnEnemy_1");
                StartCoroutine("RespawnEnemy_1");
                timer = 72f;
            }
            if ((timer > 80f) && (timer < 81f))
            {
                StopCoroutine("RespawnEnemy_1");
                StopCoroutine("RespawnEnemy_1_dup");
                StartCoroutine("RespawnEnemy_3");
                StartCoroutine("RespawnEnemy_2");
                StartCoroutine("RespawnEnemy_4_dup");
                timer = 81f;
            }

            if ((timer > 95f) && (timer < 96f)) //두번째 보스
            {
                Instantiate(obj_6, respawnTr.position + new Vector3(-1, 0, 0), Quaternion.AngleAxis(90f, Vector3.forward));
                StartCoroutine("RespawnEnemy_2_dup");
                StopCoroutine("RespawnEnemy_4_dup");
                timer = 96f; // 현 2, 2d, 3
            }

        } //

        //####

        if ((timer > 117.5) && (timer < 229))
        {
            if ((timer > 117.5f) && (timer < 118.5f))
            {
                StopCoroutine("RespawnEnemy_3");
                StartCoroutine("RespawnEnemy_2");
                timer = 118.5f; //현 2 , 2d
            }

            if ((timer > 133f) && (timer < 134f)) //두번째 보스 2마리
            {
                Instantiate(obj_6, respawnTr.position + new Vector3(-1, 2, 0), Quaternion.AngleAxis(90f, Vector3.forward));
                Instantiate(obj_6, respawnTr.position + new Vector3(-1, -2, 0), Quaternion.AngleAxis(90f, Vector3.forward));
                StopCoroutine("RespawnEnemy_2");
                StartCoroutine("RespawnEnemy_2_dup");

                timer = 134f; // 현 2d x2
            }

            if ((timer > 170f) && (timer < 171f))
            {
                StopCoroutine("RespawnEnemy_2");
                StopCoroutine("RespawnEnemy_2_dup");
                StartCoroutine("RespawnEnemy_1");
                StartCoroutine("RespawnEnemy_4_dup");

                timer = 171f; //1, 4d
            }

            if ((timer > 180f) && (timer < 181f))
            {
                StartCoroutine("RespawnEnemy_3");
                StartCoroutine("RespawnEnemy_4");

                timer = 181f; //1, 3, 4, 4d
            }

            if ((timer > 196f) && (timer < 197f)) //세번째 보스
            {
                Instantiate(obj_7, respawnTr.position + new Vector3(-1, 0, 0), Quaternion.AngleAxis(90f, Vector3.forward));

                StopCoroutine("RespawnEnemy_4_dup");
                StopCoroutine("RespawnEnemy_3");

                timer = 197f; // 1, 4
            }

            if ((timer > 222f) && (timer < 223f))
            {
                StartCoroutine("RespawnEnemy_3");
                timer = 223f; //3추가
            }

            if ((timer > 225f) && (timer < 226f))
            {
                StopCoroutine("RespawnEnemy_1");
                StartCoroutine("RespawnEnemy_3");
                StartCoroutine("RespawnEnemy_3");

                timer = 226f; //4, 3
            }

            if ((timer > 228f) && (timer < 229f))
            {
                StartCoroutine("RespawnEnemy_3");
                StartCoroutine("RespawnEnemy_3");

                timer = 229f; //3추가
            }
        }
        ////
        float Ttime_01 = 240f;
        if ((timer > Ttime_01) && (timer < Ttime_01 + 1f)) 
        {
            StopCoroutine("RespawnEnemy_4d");
            StopCoroutine("RespawnEnemy_4");
            StopCoroutine("RespawnEnemy_3");
            StartCoroutine("RespawnEnemy_8");
            StartCoroutine("RespawnEnemy_2");

            timer = Ttime_01 + 1 ; //8,2
        }

        float Ttime_02 = Ttime_01 + 16f;
        if ((timer > Ttime_02) && (timer < Ttime_02 + 1f))
        {
            StopCoroutine("RespawnEnemy_2");
            
            StartCoroutine("RespawnEnemy_4_dup");

            timer = Ttime_02 + 1; //8, 4dup
        }

        float Ttime_03 = Ttime_02 + 13.5f;
        if ((timer > Ttime_03) && (timer < Ttime_03 + 1f))
        {
            
            StartCoroutine("RespawnEnemy_4_dup");

            timer = Ttime_03 + 1; //4dup +
        }

        float Ttime_04 = Ttime_03 + 15f;
        if ((timer > Ttime_04) && (timer < Ttime_04 + 1f))
        {
            StopCoroutine("RespawnEnemy_4_dup");
            StopCoroutine("RespawnEnemy_8");
            StartCoroutine("RespawnEnemy_8_spd");

            Instantiate(obj_5, respawnTr.position + new Vector3(-1, 0, 0), Quaternion.AngleAxis(90f, Vector3.forward));
            timer = Ttime_04 + 1; //1보스, 8spd
        }

        float Ttime_05 = Ttime_04 + 25f;
        if ((timer > Ttime_05) && (timer < Ttime_05 + 1f))
        {
            StopCoroutine("RespawnEnemy_8_spd");
            StartCoroutine("RespawnEnemy_2");
            StartCoroutine("RespawnEnemy_4");
            StartCoroutine("RespawnEnemy_3");
            timer = Ttime_05 + 1;
        }

        float Ttime_06 = Ttime_05 + 13f;
        if ((timer > Ttime_06) && (timer < Ttime_06 + 1f))
        {
            StopCoroutine("RespawnEnemy_2");
            StartCoroutine("RespawnEnemy_8");
            timer = Ttime_06 + 1; // 3, 4, 8
        }
        // warning 구간, 약간의 여유 줄 것.

        float Ttime_06_1 = Ttime_06 + 14f;
        if ((timer > Ttime_06_1) && (timer < Ttime_06_1 + 1f))
        {
            StopCoroutine("RespawnEnemy_3");
            StopCoroutine("RespawnEnemy_4");
            StopCoroutine("RespawnEnemy_8");
            timer = Ttime_06_1 + 1;
        }


        float Ttime_07 = Ttime_06 + 18f;
        if ((timer > Ttime_07) && (timer < Ttime_07 + 1f)) //세번째 보스 2마리
        {
            Instantiate(obj_7, respawnTr.position + new Vector3(-1, 2, 0), Quaternion.AngleAxis(90f, Vector3.forward));
            Instantiate(obj_7, respawnTr.position + new Vector3(-1, -2, 0), Quaternion.AngleAxis(90f, Vector3.forward));
            StopCoroutine("RespawnEnemy_3");
            StopCoroutine("RespawnEnemy_4");
            StopCoroutine("RespawnEnemy_8");
            StartCoroutine("RespawnEnemy_1");

            timer = Ttime_07 + 1f ; // 현 2d x2
        }

        float Ttime_08 = Ttime_07 + 44f;
        if ((timer > Ttime_08) && (timer < Ttime_08 + 1f))
        {
            StopCoroutine("RespawnEnemy_1");
            StartCoroutine("RespawnEnemy_3");
            StartCoroutine("RespawnEnemy_2_dup");
            StartCoroutine("RespawnEnemy_2");
            timer = Ttime_08 + 1; // 3
        }

        float Ttime_09 = Ttime_08 + 7f;
        if ((timer > Ttime_09) && (timer < Ttime_09 + 1f))
        {
            StopCoroutine("RespawnEnemy_2");
            StopCoroutine("RespawnEnemy_2_dup");
            StopCoroutine("RespawnEnemy_2_3");
            StartCoroutine("RespawnEnemy_8");
            StartCoroutine("RespawnEnemy_8");
            timer = Ttime_09 + 1; // 8
        }

        float Ttime_10 = Ttime_09 + 16.5f;
        if ((timer > Ttime_10) && (timer < Ttime_10 + 1f)) //세번째 보스 1마리
        {
            Instantiate(obj_7, respawnTr.position + new Vector3(-1, 0, 0), Quaternion.AngleAxis(90f, Vector3.forward));
            StopCoroutine("RespawnEnemy_8");
            

            timer = Ttime_10 + 1f; //
        }

        float Ttime_11 = Ttime_10 + 5f;
        if ((timer > Ttime_11) && (timer < Ttime_11 + 1f)) 
        {
            StartCoroutine("RespawnEnemy_8");
          
            timer = Ttime_11 + 1f; 
        }

        float Ttime_12 = Ttime_11 + 27f;
        if ((timer > Ttime_12) && (timer < Ttime_12 + 1f))
        {
            StartCoroutine("RespawnEnemy_1_dup");
            StartCoroutine("RespawnEnemy_2");
            StartCoroutine("RespawnEnemy_3");
            StartCoroutine("RespawnEnemy_4_dup");

            timer = Ttime_12 + 1f;  // 1d, 2, 3, 4d, 8
        }

        float Ttime_13 = Ttime_12 + 19.5f;
        if ((timer > Ttime_13) && (timer < Ttime_13 + 1f)) //+ 8
        {
            
            StopCoroutine("RespawnEnemy_1_dup");
            StopCoroutine("RespawnEnemy_2");
            StopCoroutine("RespawnEnemy_3");
            StopCoroutine("RespawnEnemy_4_dup");

           
            timer = Ttime_13 + 1f; 
        }

        float Ttime_14 = Ttime_13 + 6f;
        if ((timer > Ttime_14) && (timer < Ttime_14 + 1f)) //세번째 보스 2마리
        {
            Instantiate(obj_7, respawnTr.position + new Vector3(-1, 2, 0), Quaternion.AngleAxis(90f, Vector3.forward));
            Instantiate(obj_7, respawnTr.position + new Vector3(-1, -2, 0), Quaternion.AngleAxis(90f, Vector3.forward));
            
            timer = Ttime_14 + 1f; 
        }

        float Ttime_15 = Ttime_14 + 70f;
        if ((timer > Ttime_15) && (timer < Ttime_15 + 1f)) 
        {
            StartCoroutine("RespawnEnemy_8_spd");

            timer = Ttime_15 + 1f; // 
        }

        float Ttime_16 = Ttime_15 + 50f;
        if ((timer > Ttime_16) && (timer < Ttime_16 + 1f)) 
        {
            StartCoroutine("RespawnEnemy_1_dup");
            StartCoroutine("RespawnEnemy_2_dup");
            StartCoroutine("RespawnEnemy_4_dup");

            timer = Ttime_16 + 1f; // final
        }
    }











    //****************************************
    IEnumerator RespawnEnemy_1()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_1);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_1, respawnTr.position + new Vector3(0, Random.Range(-range+0.5f, range-0.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }
    IEnumerator RespawnEnemy_1_dup()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_1_dup);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_1, respawnTr.position + new Vector3(0, Random.Range(-range + 0.5f, range - 0.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }


    IEnumerator RespawnEnemy_2()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_2);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_2, respawnTr.position + new Vector3(0, Random.Range(-range+0.5f, range - 0.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }
    IEnumerator RespawnEnemy_2_dup()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_2_dup);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_2, respawnTr.position + new Vector3(0, Random.Range(-range + 0.5f, range - 0.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }

    IEnumerator RespawnEnemy_3()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_3);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_3, respawnTr.position + new Vector3(0, Random.Range(-range + 0.5f, range - 0.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }

    IEnumerator RespawnEnemy_4()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_4);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_4, respawnTr.position + new Vector3(0, Random.Range(-range + 1.5f, range - 1.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }
    IEnumerator RespawnEnemy_4_dup()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_4_dup);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_4, respawnTr.position + new Vector3(0, Random.Range(-range + 1.5f, range - 1.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }

    IEnumerator RespawnEnemy_8()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_8);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_8, respawnTr.position + new Vector3(0, Random.Range(-range + 1.5f, range - 1.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }
    IEnumerator RespawnEnemy_8_spd()
    {
        while (true)
        {
            yield return new WaitForSeconds(resTime_8_spd);
            float range = Camera.main.orthographicSize;
            Instantiate(obj_8, respawnTr.position + new Vector3(0, Random.Range(-range + 1.5f, range - 1.5f), 0), Quaternion.AngleAxis(90f, Vector3.forward));
        }
    }

}
