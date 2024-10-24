using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject GameObject;
    ShiftEffect shiftEffect;
    AudioSource audioSource;
    public AudioClip shiftSound;
    private void Awake()
    {
        shiftEffect = GameObject.GetComponent<ShiftEffect>();
        audioSource = AudioManager.Instance.GetComponent<AudioSource>();
    }
    public void Click()
    {
    
        audioSource.PlayOneShot(shiftSound);
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            shiftEffect.boardToward = new Vector3(0, -400, 0);
        }
        else if (SceneManager.GetActiveScene().name == "ScoreScene")
        {
            shiftEffect.boardToward = new Vector3(0, 400, 0);
        }
        Invoke("nextScene",0.23f);
    }

    private void nextScene()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            SceneManager.LoadScene("ScoreScene");
        }
        else if (SceneManager.GetActiveScene().name == "ScoreScene")
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
