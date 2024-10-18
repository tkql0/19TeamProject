using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject GameObject;
    ShiftEffect shiftEffect;
    private void Awake()
    {
        shiftEffect = GameObject.GetComponent<ShiftEffect>();
    }
    public void Click()
    {
        shiftEffect.boardToward = new Vector3(0, 400, 0);
        Invoke("nextScene",0.3f);
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
