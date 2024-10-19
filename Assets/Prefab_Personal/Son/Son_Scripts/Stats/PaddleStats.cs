using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleStats : MonoBehaviour
{
    public event Action<float> OnLengthChangedEvent;
    public event Action<float> OnSpeedChangedEvent;

    public float length;
    public float moveSpeed;
    public float minLength = 3f;  
    public float maxLength = 24f;
    public float minSpeed = 2f;
    public float maxSpeed = 10f;
    
    public void Awake()
    {
        length = 6;
        moveSpeed = 6;
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

}
