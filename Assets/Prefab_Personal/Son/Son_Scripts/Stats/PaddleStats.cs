using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PaddleStats : MonoBehaviour
{
    public event Action<float> OnLengthChangedEvent;
    public event Action<float> OnSpeedChangedEvent;

    public float length {  get; private set; }
    public float moveSpeed { get; private set; }
    public float currentScore { get; private set; }
    private float minLength = 3f;
    private float maxLength = 48f;
    private float minSpeed = 2f;
    private float maxSpeed = 10f;

    public void Awake()
    {
        length = 6f;
        moveSpeed = 6;
        currentScore = 0;
    }
    public float Length
    {
        get { return length; }
        set
        {
            float clampedValue = Mathf.Clamp(value, minLength, maxLength);
            if (length != clampedValue)
            {
                length = clampedValue;
                OnLengthChangedEvent?.Invoke(clampedValue);
            }
        }
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            float clampedValue = Mathf.Clamp(value, minSpeed, maxSpeed);
            if (moveSpeed != clampedValue)
            {
                moveSpeed = clampedValue;
                OnSpeedChangedEvent?.Invoke(clampedValue);
            }
        }
    }

    public float CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
}
