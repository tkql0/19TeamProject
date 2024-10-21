using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D movementRigidbody;
    private ActionEventController controller;
    private PaddleSpeedChanger paddleSpeedChanged;
    private Vector2 movedirection = Vector2.zero;


    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();   
        controller = GetComponent<ActionEventController>();
        paddleSpeedChanged = GetComponent<PaddleSpeedChanger>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        controller.OnMoveEvent += OnMovement;
    }

    private void OnDisable()
    {
        controller.OnMoveEvent -= OnMovement;
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
    {   
        inDirection *= paddleSpeedChanged.currentSpeed;
        movementRigidbody.velocity = inDirection;
    }
}
