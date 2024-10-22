using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPannelButton : MonoBehaviour
{
    // Start is called before the first frame update
  
    public void Retry()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayBGM(AudioManager.AudioType.MenuBGM);
        SceneManager.LoadScene("LogoScene");
    }
    public void nextLevel()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayBGM(AudioManager.AudioType.MenuBGM);
        AudioManager.Instance.stageLevel++;
        if(AudioManager.Instance.stageLevel==11)
        {
            AudioManager.Instance.stageLevel = 1;
        }

        SceneManager.LoadScene("LogoScene");
    }
    public void Home()
    {
        Time.timeScale = 1f;
        GameManager.Instance.isMultiplay = false;
        AudioManager.Instance.PlayBGM(AudioManager.AudioType.MenuBGM);
        SceneManager.LoadScene("MenuScene");
    }

}
