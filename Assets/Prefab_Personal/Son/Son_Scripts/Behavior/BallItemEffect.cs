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
                Debug.Log("볼 무적");
                break;
        }
    }

    private void ApplySizeChange(float inValue)
    {
        stats.Size += inValue;
    }

    private void ApplyDouble(float inValue)
    {
        GameObject newBall = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
        if (newBall.TryGetComponent<BallStats>(out var newBallStats))
        {
            newBallStats.Size = stats.Size;
            //newBallStats.currentScale = stats.currentScale;
        }
        //newBall.transform.localScale = stats.currentScale;
        if (newBall.TryGetComponent<BallItemEffect>(out var outEffect))
        {
            outEffect.effectHandler = effectHandler;
        }
        GameManager.Instance.BallList.Add(newBall);
        //SetBasic(newBall);
        //newBall.transform.localScale = stats.currentScale;
    }

    //private void SetBasic(GameObject newBall)
    //{
    //    newBall.TryGetComponent<BallItemEffect>(out var outEffect);
    //    Debug.Log("적용전 : " + newBall.transform.localScale);
    //    if (newBall.transform.localScale == Vector3.zero)
    //    {
    //        newBall.transform.localScale = stats.currentScale;
    //    }
    //    newBall.transform.localScale = stats.currentScale;
    //    Debug.Log("적용후 : " + newBall.transform.localScale);
    //    outEffect.effectHandler = effectHandler;
    //}
}
