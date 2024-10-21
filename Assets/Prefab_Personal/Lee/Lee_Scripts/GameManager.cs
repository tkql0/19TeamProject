using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
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
    private GameObject playerObject1;

    public bool isGameStart = false;

    private void Awake()
    {
        if (Instance == null)                           // Singletone class
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null) Destroy(gameObject);

        pool = GetComponent<ObjectPool_KIM>();
    }

    private void OnEnable()
    {
        // 씬이 로드될 때마다 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;

        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 이름이 MainScene인 경우 MakePlayer 호출
        if (scene.name == "MainScene_Special")
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
            GameOver();
        }
        else
        {
            //Invoke("LaunchBall", 1f);                 // When missed all balls, wait 1sec and launch the next ball 
            isGameStart = false;

            GameObject newBall = pool.SpawnFromPool("Ball");
            BallList.Add(newBall);
        }
    }

    public GameObject SpawnBall(Transform InBallPosition)                 // random direction 
    {
        //GameObject newBall = Instantiate(Ball, InBallPosition.position, Quaternion.identity);
        GameObject newBall = pool.SpawnFromPool("Ball");
        BallList.Add(newBall);
        newBall.transform.position = InBallPosition.position;

        return newBall;
    }

    private void MakePlayer()
    {
        playerObject1 = Instantiate(player1);
        playerObject1.TryGetComponent<ItemEffectHandler>(out var outHandler);
        BallItemEffect newBall = SpawnBall(playerObject1.transform).GetComponent<BallItemEffect>();
        newBall.effectHandler = outHandler;
        //SpawnBall(playerObject1.transform).TryGetComponent<BallItemEffect>(out var outEffect);
        //outEffect.effectHandler = outHandler;

        if (isMultiplay)
        {
            GameObject playerObject2 = Instantiate(player2);
        }
    }
}
