using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleItemEffect : MonoBehaviour
{
    private ItemEffectHandler effectHandler;
    private PaddleStats stats;
    //private Item item;
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
    private void OnPaddleChange(Item.ItemType itemType)// need parameter some value
    {
        switch(itemType)
        {
            case Item.ItemType.PaddleIncrease:
                ApplyLengthChange(2);//need item some value(lick increase 12)
                break;
        }
    }

    private void ApplyLengthChange(float inScaleValue)
    {
        Debug.Log(stats.Length);
        Debug.Log(inScaleValue);
        stats.Length *= inScaleValue;
        Debug.Log(stats.Length);
        //Vector3 newScale = transform.localScale;
        //newScale.x = inScaleValue;
        //transform.localScale = newScale;
    }
}
