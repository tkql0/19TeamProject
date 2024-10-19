using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleItemEffect : MonoBehaviour
{
    private ItemEffectHandler effectHandler;
    private PaddleStats stats;


    private void Awake()
    {
        effectHandler = GetComponent<ItemEffectHandler>();
        stats = GetComponent<PaddleStats>();
    }

    private void OnEnable()
    {
        effectHandler.OnItemToPaddleEvent += OnPaddleChange;
    }

    private void OnDisable()
    {
        effectHandler.OnItemToPaddleEvent -= OnPaddleChange;
    }


    private void OnPaddleChange(PaddleItemType inPaddleType, float inValue)
    {
        switch (inPaddleType)
        {
            case (PaddleItemType.PaddleIncreaseLength or PaddleItemType.PaddleDecreaseLength):
                ApplyLengthChange(inValue);
                break;

            case PaddleItemType.PaddleIncreaseSpeed or PaddleItemType.PaddleDecreaseSpeed:
                ApplySpeedChange(inValue);
                break;
        }
    }

    private void ApplyLengthChange(float inScaleValue)
    {
        stats.Length *= inScaleValue;
    }

    private void ApplySpeedChange(float inSpeedValue)
    {
        stats.moveSpeed += inSpeedValue;
        Debug.Log(stats.moveSpeed);
    }
}
