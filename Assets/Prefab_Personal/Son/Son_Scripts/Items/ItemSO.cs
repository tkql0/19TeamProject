using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "NewItemSO/Item",order =0)]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public BallItemType ballType;
    public PaddleItemType paddleType;
    public float value;
    public int SetLayer;
    public Sprite itemSprite;
}
