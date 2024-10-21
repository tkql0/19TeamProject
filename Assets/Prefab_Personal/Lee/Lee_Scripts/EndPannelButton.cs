using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPannelButton : MonoBehaviour
{
    // Start is called before the first frame update
  
    public void Retry()
    {
        AudioManager.Instance.PlayBGM(AudioManager.AudioType.MenuBGM);
        SceneManager.LoadScene("LogoScene");
    }
    public void nextLevel()
    {
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
        AudioManager.Instance.PlayBGM(AudioManager.AudioType.MenuBGM);
        SceneManager.LoadScene("MenuScene");
    }

}
