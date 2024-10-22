using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int level;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenScene()
    {
        AudioManager.Instance.stageLevel = level;
        SceneManager.LoadScene("LogoScene");


    }
}
