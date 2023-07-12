using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject bullet;

    public float delayTime = 0.2f;
    public float startTime = 1.0f;

    void Start()
    {
        InvokeRepeating("Fire", startTime, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void Fire()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);
        }
    }
}
