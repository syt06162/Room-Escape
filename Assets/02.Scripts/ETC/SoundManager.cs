using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioClip oneEffect, twoEffect;
    AudioSource audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        oneEffect = Resources.Load<AudioClip>("OneEffect");
        twoEffect = Resources.Load<AudioClip>("TwoEffect");
        
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void Start()
    {
        
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "OneClick":
                audioSource.PlayOneShot(oneEffect);
                break;
            case "TwoClick":
                audioSource.PlayOneShot(twoEffect);
                break;
        }
    }

    //EffectManager.Instance.PlaySound("oneClick");
}
