using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;
    
    public AudioClip menuBGM;
    public AudioClip hammerBGM;
    public AudioClip endBGM;

    public enum AudioType
    {
        MenuBGM,
        HammerBGM,
        EndBGM
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
            case AudioType.HammerBGM:
                audioSource.PlayOneShot(hammerBGM);
                break;
            case AudioType.EndBGM:
                audioSource.clip = endBGM;
                audioSource.Play();
                break;
            default:
                throw new System.Exception("Invalid AudioType");
                break;
        }
    }
}