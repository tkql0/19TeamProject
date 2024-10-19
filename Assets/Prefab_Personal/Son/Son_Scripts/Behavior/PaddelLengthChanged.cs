using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddelLengthChanged : MonoBehaviour
{
    private PaddleStats paddleStats;

    private void Awake()
    {
        paddleStats = GetComponentInParent<PaddleStats>();
    }
    private void OnEnable()
    {
        paddleStats.OnLengthChangedEvent += OnLengthChanged;
    }

    private void OnDisable()
    {
        paddleStats.OnLengthChangedEvent -= OnLengthChanged;
    }

    private void Start()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = paddleStats.length;
        transform.localScale = newScale;
    }

    private void OnLengthChanged(float inScaleValue)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = inScaleValue;
        transform.localScale = newScale;
    }
}
