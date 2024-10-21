using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectHandler : MonoBehaviour
{
    public event Action<BallItemType, float> OnItemToBallEvent;
    public event Action<PaddleItemType, float> OnItemToPaddleEvent;



    public void OnTriggerEnter2D(Collider2D incollision)
    {
        int ItemLayer = LayerMask.NameToLayer("Item");
        if (incollision.gameObject.layer == ItemLayer)
        {
            ItemSOHolder itemSOHolder = incollision.GetComponent<ItemSOHolder>();
            ItemSO item = itemSOHolder.itemSO;
            if (item != null)
            {
                HandleItemEffect(item);
            }
        }
    }


    private void HandleItemEffect(ItemSO inItem)
    {
        switch (inItem.itemType)
        {
            case ItemType.Ball:
                CallOnItemToBallEvent(inItem.ballType, inItem.value);
                break;
            case ItemType.Paddle:
                CallItemToPaddleEvent(inItem.paddleType, inItem.value);
                break;
        }
    }

    private void CallOnItemToBallEvent(BallItemType inBallItemType, float inValue)
    {
        OnItemToBallEvent?.Invoke(inBallItemType, inValue);
    }

    private void CallItemToPaddleEvent(PaddleItemType inPaddleItemType, float inValue)
    {
        OnItemToPaddleEvent?.Invoke(inPaddleItemType, inValue);
    }

}
