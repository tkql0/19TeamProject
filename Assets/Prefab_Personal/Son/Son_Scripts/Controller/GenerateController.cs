using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GenerateController : MonoBehaviour
{
    public enum PlayerType
    {
        Player1,
        Player2
    }

    [SerializeField] private PlayerType playerType;

    private PlayerInputAction playerInput;
    private InputActionMap actionMap;
    public UnityAction<Vector2> OnMoveEvent;

    private void Awake()
    {
        playerInput = new PlayerInputAction();
        actionMap = GetActionMapToEnum(playerType);
    }

    private void OnEnable()
    {
        actionMap["Move"].performed += PlayerMove;
        actionMap["Move"].canceled += PlayerMove;
        actionMap.Enable();
    }


    private void OnDisable()
    {
        actionMap["Move"].performed -= PlayerMove;
        actionMap["Move"].canceled -= PlayerMove;
        actionMap.Disable();
    }


    private InputActionMap GetActionMapToEnum(PlayerType playerType)
    {
        return playerType switch
        {
            PlayerType.Player1 => playerInput.Player1,
            PlayerType.Player2 => playerInput.Player2,
            _ => null
        };
    }

    public void PlayerMove(InputAction.CallbackContext value)
    {
        Vector2 moveValue = value.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(moveValue);
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        Vector2 moveValue = value.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(moveValue);
    }

}
