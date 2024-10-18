using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject GameObject;
    ScoreBoard scoreBoard;
    private void Awake()
    {
        scoreBoard = GameObject.GetComponent<ScoreBoard>();
    }
    public void Click()
    {
        scoreBoard.boardToward = new Vector3(0, 400, 0);
        Invoke("nextScene",0.5f);
    }

    private void nextScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
