using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddelMovement : MonoBehaviour
{
    private Rigidbody2D movementRigidbody;
    private GenerateController controller;
    private PaddleSpeedChanged paddleSpeedChanged;
    private Vector2 moveDirection = Vector2.zero;


    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<GenerateController>();
        paddleSpeedChanged = GetComponent<PaddleSpeedChanged>();
    }

    private void OnEnable()
    {
        controller.OnMoveEvent += OnMovement;
    }

    private void OnDisable()
    {
        controller.OnMoveEvent -= OnMovement;
    }

    private void Start()
    {
        movementRigidbody.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }
    private void OnMovement(Vector2 inDirection)
    {
        moveDirection = inDirection;
    }

    private void ApplyMovement(Vector2 inDirection)
    {
        inDirection *= paddleSpeedChanged.currentSpeed;
        movementRigidbody.velocity = inDirection;
    }
}
