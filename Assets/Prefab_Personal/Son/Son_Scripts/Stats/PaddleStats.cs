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

    public void Awake()
    {
        length = 3;
        moveSpeed = 5;
    }
    public float Length
    {
        get { return length; }
        set
        {
            if (length != value)
            {
                length = value;
                OnLengthChangedEvent?.Invoke(value);
            }
        }
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            if (moveSpeed != value)
            {
                moveSpeed = value;
                OnSpeedChangedEvent?.Invoke(value);
            }
        }
    }

}
