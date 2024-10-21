using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddelMovement : MonoBehaviour
{
    private Rigidbody2D movementRigidbody;
    private GenerateController controller;
    private PaddleSpeedChanger paddleSpeedChanger;
    private Vector2 moveDirection = Vector2.zero;


    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();
        controller = GetComponent<GenerateController>();
        paddleSpeedChanger = GetComponent<PaddleSpeedChanger>();
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

    private void Update()
    {
        if (GameManager.Instance.isGameStart)
        {
            return;
        }
        else
        {
            if(GameManager.Instance.BallList[0].TryGetComponent<Ball>(out var outBall))
            {
                outBall.transform.position
                = transform.position + new Vector3(0, 1);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.Instance.isGameStart = true;
                    outBall.LaunchBall();
                }
            }
        }
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
        inDirection *= paddleSpeedChanger.currentSpeed;
        movementRigidbody.velocity = inDirection;
    }
}
