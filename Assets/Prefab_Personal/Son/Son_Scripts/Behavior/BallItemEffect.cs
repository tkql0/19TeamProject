using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class BallItemEffect : MonoBehaviour
{
    [SerializeField] private ItemEffectHandler effectHandler;
    private BallStats stats;
    private void Awake()
    {
        stats = GetComponent<BallStats>();
    }

    private void OnEnable()
    {
        if (effectHandler != null)
        {
            effectHandler.OnItemToBallEvent += OnBallChange;
        }
    }

    private void OnDisable()
    {
        if (effectHandler != null)
        {
            effectHandler.OnItemToBallEvent -= OnBallChange;
        }
    }

    private void OnBallChange(BallItemType inPaddleType, float inValue)
    {
        switch (inPaddleType)
        {
            case BallItemType.BallIncreaseSize or BallItemType.BallDecreaseSize:
                ApplySizeChange(inValue);
                break;

            case BallItemType.BallNumberDouble:
                ApplyDouble(inValue);
                break;
            case BallItemType.BallInvincible:
                Debug.Log("º¼ ¹«Àû");
                break;
        }
    }

    private void ApplySizeChange(float inValue)
    {
        stats.Size += inValue;
    }

    private void ApplyDouble(float inValue)
    {
        GameObject newBall =  Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
        if (gameObject.TryGetComponent<BallItemEffect>(out var originalEffect))
        {
            if (newBall.TryGetComponent<BallItemEffect>(out var newEffect))
            {
                CopySerializedFields(originalEffect, newEffect);
            }
        }

    }
    private void CopySerializedFields(BallItemEffect source, BallItemEffect destination)
    {
        var fields = typeof(BallItemEffect).GetFields(System.Reflection.BindingFlags.Instance |
                                                      System.Reflection.BindingFlags.NonPublic |
                                                      System.Reflection.BindingFlags.Public);

        foreach (var field in fields)
        {
            field.SetValue(destination, field.GetValue(source));
        }
    }
}
