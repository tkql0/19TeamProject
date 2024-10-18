using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddelMovement : MonoBehaviour
{
    private Rigidbody2D movementRigidbody;
    private GenerateController controller;
    private PaddleStats paddleStats;
    private Vector2 moveDirection = Vector2.zero;
    private float baseSpeed;
    private float applySpeed;

    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<GenerateController>();
        paddleStats = GetComponent<PaddleStats>();
    }

    private void OnEnable()
    {
        controller.OnMoveEvent += OnMovement;
        paddleStats.OnSpeedChangedEvent += OnSpeedChanged;
    }

    private void OnDisable()
    {
        controller.OnMoveEvent -= OnMovement;
        paddleStats.OnSpeedChangedEvent -= OnSpeedChanged;
    }

    private void Start()
    {
        movementRigidbody.velocity = Vector2.zero;
        baseSpeed = paddleStats.MoveSpeed;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }
    private void OnMovement(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void OnSpeedChanged(float speed)
    {
        applySpeed = speed;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= baseSpeed + applySpeed;
        movementRigidbody.velocity = direction;
    }
}
