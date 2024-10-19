using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_KIM : MonoBehaviour
{
    private Rigidbody2D movementRigidbody;
    private ActionEventController controller;
    private PaddleStats paddleStats;
    private Vector2 movedirection = Vector2.zero;
    private float applySpeed;


    private void Awake()
    {
        movementRigidbody = GetComponent<Rigidbody2D>();   
        controller = GetComponent<ActionEventController>();
        paddleStats = GetComponent<PaddleStats>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        controller.OnMoveEvent += OnMovement;
        paddleStats.OnSpeedChangedEvent += OnSpeed;
    }

    private void OnDisable()
    {
        controller.OnMoveEvent -= OnMovement;
        paddleStats.OnSpeedChangedEvent -= OnSpeed;
    }

    private void Update()
    {
        if(GameManager.Instance.isGameStart)
        {
            return;
        }

        if(Input.GetKeyDown("Space"))
        {
            GameManager.Instance.isGameStart = true;
        }
    }


    private void FixedUpdate()
    {
        ApplyMovement(movedirection, applySpeed);
    }

    private void OnMovement(Vector2 inDirection)
    {
        movedirection = inDirection;

        if(!GameManager.Instance.isGameStart)
        {
            GameManager.Instance.BallList[0].transform.position = inDirection;
        }
    }

    private void OnSpeed(float speed)
    {
        applySpeed = speed;
    }

    private void ApplyMovement(Vector2 inDirection, float speed)
    {   //TODO : Magic Number --> make PabbleSO.speed
        inDirection = inDirection * speed;
        movementRigidbody.velocity = inDirection;
    }
}
