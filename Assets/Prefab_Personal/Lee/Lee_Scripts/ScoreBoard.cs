using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject ScoreRecord;
    [SerializeField] GameObject UICanvas;
    public Vector3 boardToward = Vector3.zero;
    GameObject ScoreText;
    

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        boardToward = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        List<int> scoreList = GameManager.Instance.scoreRanking;
        scoreList = new List<int> { 15, 10, 8, 7 };

        for (int i = 0; i < scoreList.Count; i++)
        {
            GameObject score  = Instantiate(ScoreRecord, UICanvas.transform.position , Quaternion.identity);
            score.transform.position += new Vector3(0, 100 - 50 * i, 0);
            score.transform.parent = UICanvas.transform;
            ScoreText = score.transform.GetChild(0).gameObject;
            Text scoreText = ScoreText.GetComponent<Text>();
            scoreText.text = $"{i+1}. {scoreList[i]} pt";
        }

    }

    // Update is called once per frame
    void Update()
    {
        UICanvas.transform.localPosition = Vector3.MoveTowards(UICanvas.transform.localPosition, boardToward, 2000 * Time.deltaTime);
    }
}
