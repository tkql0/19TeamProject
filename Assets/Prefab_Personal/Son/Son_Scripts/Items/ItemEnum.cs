using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Ball,
    Paddle
}

public enum BallItemType
{
    BallIncreaseSize,
    BallDecreaseSize,
    BallNumberDouble,
    BallInvincible
}

public enum PaddleItemType
{
    PaddleIncreaseSpeed,
    PaddleDecreaseSpeed,
    PaddleIncreaseLength,
    PaddleDecreaseLength,
    PaddleGetScore
}
