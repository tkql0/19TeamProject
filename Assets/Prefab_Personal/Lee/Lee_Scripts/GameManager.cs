using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject Ball;
    public List<GameObject> BallList;
    public int currentScore;
    public int highScore;
    public int life;                                // 0 -> GameOver
    public float time;
    private bool isMultiplay;                       // flase : 1 player ,  true : 2 players

    private void Awake()
    {
        if (Instance == null)                           // Singletone class
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null) Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageStart()
    {
        life = 3;
    }

    public void StageClear()
    {
        highScore = Mathf.Max(highScore, currentScore);

    }

    public void GameOver()
    {
        highScore = Mathf.Max(highScore, currentScore);
    }

    public void MissBall(GameObject Ball)
    {
        BallList.Remove(Ball);
        Destroy(Ball);
        if (BallList.Count == 0 )
        {
            MissAllBall();
        }
    }

    public void MissAllBall()
    {
        life--;
        if (life ==0)                             
        {
            GameOver();
        }
        else
        {
            Thread.Sleep(1000);                 // When missed all balls, wait 1sec and launch the next ball 
            LaunchBall();
        }
    }

    private void LaunchBall()                 // random direction 
    {

    }
}
