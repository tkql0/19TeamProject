using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedChanger : MonoBehaviour
{
    private PaddleStats paddleStats;
    public float currentSpeed { get; private set; }

    private void Awake()
    {
        paddleStats = GetComponentInParent<PaddleStats>();
        //currentSpeed = paddleStats.moveSpeed;
    }

    private void OnEnable()
    {
        paddleStats.OnSpeedChangedEvent += OnSpeedChanged;
    }

    private void OnDisable()
    {
        paddleStats.OnSpeedChangedEvent -= OnSpeedChanged;
    }

    private void Start()
    {
        currentSpeed = paddleStats.moveSpeed;
    }

    private void OnSpeedChanged(float inSpeedValue)
    {
        currentSpeed = inSpeedValue;
    }

}
