using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    int level = AudioManager.Instance.stageLevel;
    private void Awake()
    {
        Invoke("NextScene", 1.5f);
    }
    
    private void NextScene()
    {
        if (level == 0)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene($"MainScene {level}" );
        }
    }
}
