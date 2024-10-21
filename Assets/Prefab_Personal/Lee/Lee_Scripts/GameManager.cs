using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Ball;
    public List<GameObject> BallList = new List<GameObject>();
    public ObjectPool_KIM pool;
    public List<int> scoreRanking = new List<int>();          //this list will use in ScoreBoard
    public int currentScore;
    public int highScore;
    public int life;                                // 0 -> GameOver
    public float time;
    public bool isMultiplay;                       // flase : 1 player ,  true : 2 players
    public GameObject player1;
    public GameObject player2;

    public bool isGameStart = false;

    public GameObject endPanel;
    public GameObject clearTxt;
    public EndPanelController endPanelController;
    public List<Sprite> castings;
    public GameObject endAnimation;
    private EndPanelAnimationController endpanelanimation;
    
    private void Awake()
    {
        if (Instance == null)                           // Singletone class
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null) Destroy(gameObject);
        Time.timeScale = 1f;

        pool = GetComponent<ObjectPool_KIM>();
        endpanelanimation = endAnimation.GetComponent<EndPanelAnimationController>();
    }

    private void OnEnable()
    {
        // ���� �ε�� ������ �̺�Ʈ ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // �̺�Ʈ ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �� �̸��� MainScene�� ��� MakePlayer ȣ��
        if (scene.name == "MainScene")
        {
            Invoke(nameof(MakePlayer), 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void StageStart()
    {
        life = 3;
        currentScore = 0;
        //LaunchBall();
    }
    
    public void GameOver(bool clear)
    {
        EndPanel(clear);
        Time.timeScale = 0;
        endPanel.SetActive(true);
        endPanelController.ClearText(clear);
        endPanelController.SetScore(currentScore);
        endPanelController.SetCastingImage(castings[3]);
        endpanelanimation.Down();
        
        highScore = Mathf.Max(highScore, currentScore);
        scoreRanking.Add(currentScore);
        scoreRanking.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));
    }
    
    public void EndPanel(bool clear)
    {
        if (clear)
        {
            AudioManager.Instance.PlayBGM(AudioManager.AudioType.ClearBGM);
        }
        else
        {
            AudioManager.Instance.PlayBGM(AudioManager.AudioType.FailBGM);
        }
    }

    public void CalculateScore()
    {
        Sprite sprite;
        if (currentScore < 500)
        {
            sprite = castings[0];
        }
        else if (currentScore < 1000)
        {
            sprite = castings[1];
        }
        else if (currentScore < 2000)
        {
            sprite = castings[2];
        }
        else
        {
            sprite = castings[3];
        }
        endPanelController.SetCastingImage(sprite);
    }

    public void MissBall(GameObject inBall)
    {
        BallList.Remove(inBall);
        //Destroy(Ball);
        inBall.SetActive(false);

        if (BallList.Count == 0)
        {
            MissAllBall();
        }
    }

    public void MissAllBall()
    {
        life--;
        if (life == 0)
        {
            GameOver(false);
        }
        else
        {
            //Invoke("LaunchBall", 1f);                 // When missed all balls, wait 1sec and launch the next ball 
            isGameStart = false;

            GameObject newBall = pool.SpawnFromPool("Ball");
            BallList.Add(newBall);
        }
    }

    private void LaunchBall(Transform InBallPosition)                 // random direction 
    {
        //BallList.Add(Instantiate(Ball, InBallPosition.position, Quaternion.identity));
        GameObject newBall = pool.SpawnFromPool("Ball");
        newBall.transform.position = InBallPosition.position;
        BallList.Add(newBall);
    }

    //public void BallNumber()
    //{

    //}
    //public void BallPower()
    //{

    //}

    //public void PaddleIncrease()
    //{

    //}

    private void MakePlayer()
    {
        GameObject playerObject1 = Instantiate(player1);

        //BallList.Add(Instantiate(Ball,
        //    playerObject1.transform.position + new Vector3(0, 1), Quaternion.identity));
        GameObject newBall = pool.SpawnFromPool("Ball");
        BallList.Add(newBall);

        if (isMultiplay)
        {
            GameObject playerObject2 = Instantiate(player2);
        }
    }
}
