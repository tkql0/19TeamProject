using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallStats : MonoBehaviour
{
    public event Action<float> OnSizeChangedEvent;
    public event Action OnBallDoubleEvent;

    public float size { get; private set; }
    public float power { get; private set; }
    public bool isDouble { get; private set; }
    public bool isInvincible { get; private set; }

    public float MaxDoubleNum = 3;
    private float minSize = 2f;
    private float maxSize = 10f;

    public void Awake()
    {
        size = 6.0f;
        power = 1f;
        isDouble = false;
        isInvincible = false;
    }

    public float Size
    {
        get { return size; }
        set
        {
            float clampedValue = Mathf.Clamp(value, minSize, maxSize);
            if (size != clampedValue)
            {
                size = clampedValue;
                OnSizeChangedEvent?.Invoke(clampedValue);
            }
        }
    }

    public bool IsDouble
    {
        get { return isDouble; }
        set
        {
            
            bool isDouble = value;
            if (isDouble)
            {
                isDouble = false;
                OnBallDoubleEvent?.Invoke();
            }
        }
    }
}
