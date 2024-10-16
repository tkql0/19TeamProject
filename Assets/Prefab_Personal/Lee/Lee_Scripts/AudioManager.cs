using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;
    public AudioClip menuBGM;
    public AudioClip stageBGM;

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
        PlayMenuBGM();
    }

    public void PlayMenuBGM()
    {
        audioSource.clip = menuBGM;
        audioSource.Play();
    }

    public void PlayStageBGM()
    {
        audioSource.clip = stageBGM;
        audioSource.Play();
    }
}
