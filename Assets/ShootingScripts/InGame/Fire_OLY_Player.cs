using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_OLY_Player : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject bullet;

    public float delayTime = 0.2f;
    public float startTime = 1.0f;

    public AudioClip sfx;
    public AudioSource audioSource;

    void Start()
    {
        //InvokeRepeating("Fire", startTime, delayTime);
    }

    float currentTime = 0f;

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > delayTime)
        {
            Fire();
            currentTime = 0f;
        }
    }

    void Fire()
    {
        audioSource.PlayOneShot(sfx, 0.3f);
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);
        }
    }
}
