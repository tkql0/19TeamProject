using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject Ball;
    public List<GameObject> BallList =new List<GameObject>();
    public List<int> scoreRanking = new List<int>();          //this list will use in ScoreBoard
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
        currentScore = 0;
        LaunchBall();
    }

    public void StageClear()
    {
        highScore = Mathf.Max(highScore, currentScore);
        scoreRanking.Add(currentScore);
        scoreRanking.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));                 // Sort in Descending order
    }

    public void GameOver()
    {
        highScore = Mathf.Max(highScore, currentScore);
        scoreRanking.Add(currentScore);
        scoreRanking.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));
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
            Invoke("LaunchBall", 1f);                 // When missed all balls, wait 1sec and launch the next ball 
            
        }
    }

    private void LaunchBall()                 // random direction 
    {
        BallList.Add(Instantiate(Ball,new Vector3(0,-3,0),Quaternion.identity));
    }

    public void BallNumber()
    {

    }
    public void BallPower()
    {

    }

    public void PaddleIncrease()
    {

    }
}
