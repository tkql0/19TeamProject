using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class BallItemEffect : MonoBehaviour
{
    [SerializeField] public List<ItemEffectHandler> effectHandler;
    private BallStats stats;
    private void Awake()
    {
        stats = GetComponent<BallStats>();
    }

    private void OnEnable()
    {
        if (effectHandler != null)
        {
            foreach (var handler in effectHandler)
            {
                if (handler != null)
                {
                    handler.OnItemToBallEvent += OnBallChange;
                }
            }
        }
    }

    private void OnDisable()
    {
        if (effectHandler != null)
        {
            foreach (var handler in effectHandler)
            {
                if (handler != null)
                {
                    handler.OnItemToBallEvent -= OnBallChange;
                }
            }
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
                //Debug.Log("�� ����");
                break;
        }
    }

    private void ApplySizeChange(float inValue)
    {
        stats.Size += inValue;
    }

    private void ApplyDouble(float inValue)
    {
        stats.IsDouble = true;
    }
}
