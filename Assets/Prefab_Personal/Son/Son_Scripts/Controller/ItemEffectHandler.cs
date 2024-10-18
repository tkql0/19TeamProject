using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectHandler : MonoBehaviour
{
    public event Action<Item.ItemType> OnItemToPaddleEvent;
    public event Action<Item.ItemType> OnItemToBallEvent;
    //private Item item;
    private void OnTriggerEnter2D(Collider2D Incollision)
    {
        if (Incollision.gameObject.layer == 10)
        {
            Debug.Log("df");
            Item item = Incollision.GetComponent<Item>();
            if (item != null)
            {
                HandleItemEffect(item.itemType); //(item.itemType, item.effectValue);
                //Destroy(Incollision.gameObject); in Item Destroy(gameObject);
            }
        }
    }

    private void HandleItemEffect(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.BallNumber:
                CallOnItemTOBallEvent(itemType);
                break;
            case Item.ItemType.BallPower:
                CallOnItemTOBallEvent(itemType);
                break;
            case Item.ItemType.PaddleIncrease:
                CallItemToPaddleEvent(itemType);
                break;
        }
    }

    private void CallItemToPaddleEvent(Item.ItemType itemType)
    {
        OnItemToPaddleEvent?.Invoke(itemType);
    }

    private void CallOnItemTOBallEvent(Item.ItemType itemType)
    {
        OnItemToBallEvent?.Invoke(itemType);
    }
}
