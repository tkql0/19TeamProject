using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddelLengthChanged : MonoBehaviour
{
    private PaddleStats paddleStats;
    private BoxCollider2D paddlecollider;
    [SerializeField] private BoxCollider2D playerCollider;

    private void Awake()
    {
        paddleStats = GetComponentInParent<PaddleStats>();
        paddlecollider = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        paddleStats.OnLengthChangedEvent += OnLengthChanged;
    }

    private void OnDisable()
    {
        paddleStats.OnLengthChangedEvent -= OnLengthChanged;
    }

    private void OnLengthChanged(float inScaleValue)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = inScaleValue;
        transform.localScale = newScale;
        SetColliderSize();
    }

    private void SetColliderSize()
    {
        playerCollider.size = paddlecollider.size;
    }
}
