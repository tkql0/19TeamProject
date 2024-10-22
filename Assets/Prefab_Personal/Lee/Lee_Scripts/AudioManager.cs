using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;
    public int stageLevel;
    
    public AudioClip menuBGM;
    public AudioClip hammerBGM;
    public AudioClip startBGM;
    public AudioClip failBGM;
    public AudioClip clearBGM;

    public enum AudioType
    {
        MenuBGM,
        FailBGM,
        StartBGM,
        ClearBGM,
        HammerBGM
    }
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM(AudioType.MenuBGM);
    }

    public void PlayBGM(AudioType audioType)
    {
        switch (audioType)
        {
            case AudioType.MenuBGM:
                audioSource.clip = menuBGM;
                audioSource.Play();
                break;
            case AudioType.FailBGM:
                audioSource.clip = failBGM;
                audioSource.Play();
                break;
            case AudioType.StartBGM:
                audioSource.clip = startBGM;
                break;
            case AudioType.ClearBGM:
                audioSource.clip = clearBGM;
                audioSource.Play();
                break;
            case AudioType.HammerBGM:
                audioSource.PlayOneShot(hammerBGM);
                break;
            default:
                throw new System.Exception("Invalid AudioType");
                break;
        }
    }
}