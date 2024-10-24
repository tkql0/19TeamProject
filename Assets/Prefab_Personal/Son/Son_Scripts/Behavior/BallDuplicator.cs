using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BallDuplicator : MonoBehaviour
{
    private BallStats ballStats;

    private void Awake()
    {
        ballStats = GetComponent<BallStats>();
    }

    private void OnEnable()
    {
        ballStats.OnBallDoubleEvent += OnBallDuplicte;
    }

    private void OnDisable()
    {
        ballStats.OnBallDoubleEvent -= OnBallDuplicte;
    }

    private void OnBallDuplicte()
    {
        GameObject newBall = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
        if (newBall.TryGetComponent<BallStats>(out var newBallStats))
        {
            newBallStats.Size = ballStats.Size;
        }
        GameManager.Instance.BallList.Add(newBall);
    }
}
