using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D movementRigidbody;
    private ActionEventController controller;
    private Vector2 movedirection = Vector2.zero;

    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();   
        controller = GetComponent<ActionEventController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEvent += OnMovement;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movedirection);
    }

    private void OnMovement(Vector2 inDirection)
    {
        movedirection = inDirection;
    }

    private void ApplyMovement(Vector2 inDirection)
    {   //TODO : Magic Number --> make PabbleSO.speed
        inDirection = inDirection * 5;
        movementRigidbody.velocity = inDirection;
    }
}
