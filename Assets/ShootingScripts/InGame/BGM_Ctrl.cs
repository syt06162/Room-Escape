using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Ctrl : MonoBehaviour
{
    public AudioClip bgm;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
