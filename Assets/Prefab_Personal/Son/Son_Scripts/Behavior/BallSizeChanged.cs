using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BallSizeChanged : MonoBehaviour
{
    private BallStats ballStats;

    private void Awake()
    {
        ballStats = GetComponent<BallStats>();
    }

    private void OnEnable()
    {
        ballStats.OnSizeChangedEvent += OnSizeChanged;
    }

    private void OnDisable()
    {
        ballStats.OnSizeChangedEvent -= OnSizeChanged;
    }

    private void Start()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = ballStats.size;
        newScale.y = newScale.x;
        transform.localScale = newScale;
    }

    private void OnSizeChanged(float inScaleValue)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = inScaleValue;
        newScale.y = inScaleValue;
        transform.localScale = newScale;
        ballStats.currentScale = transform.localScale;
        Debug.Log("currentScale + " + ballStats.currentScale);
    }
}
