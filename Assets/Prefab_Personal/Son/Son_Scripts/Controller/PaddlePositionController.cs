using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePositionController : MonoBehaviour
{
    private enum DirectionType
    {
        Left,
        Right,
    }

    [SerializeField] DirectionType directionType;

    [SerializeField] private GameObject basePaddle;
    [SerializeField] private GameObject targetPaddle;
    private BoxCollider2D baseCollider;
    private BoxCollider2D targetCollider;
    Vector2 paddlePosition = Vector2.zero;

    private void Awake()
    {
        baseCollider = basePaddle.GetComponent<BoxCollider2D>();
        targetCollider = targetPaddle.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ChangePaddleLenth();
    }
    private void ChangePaddleLenth()
    {
        switch (directionType)
        {
            case DirectionType.Left:
                paddlePosition = new Vector2(baseCollider.bounds.min.x - targetCollider.bounds.extents.x, basePaddle.transform.position.y);
                targetPaddle.transform.position = new Vector2(paddlePosition.x, paddlePosition.y);
                break;
            case DirectionType.Right:
                paddlePosition = new Vector2(baseCollider.bounds.max.x + targetCollider.bounds.extents.x, basePaddle.transform.position.y);
                targetPaddle.transform.position = new Vector2(paddlePosition.x, paddlePosition.y);
                break;
        }
    }
}
