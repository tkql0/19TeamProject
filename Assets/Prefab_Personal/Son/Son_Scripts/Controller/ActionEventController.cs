using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEventController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
}
