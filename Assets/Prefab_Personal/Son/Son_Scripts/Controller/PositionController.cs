using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    private enum DirectionType
    {
        Left,
        Right
    }

    [SerializeField] DirectionType directionType;

    [SerializeField] private GameObject basePaddle;
    [SerializeField] private GameObject sidePaddle;
    private BoxCollider2D baseCollider;
    private BoxCollider2D sideCollider;
    Vector2 paddleEdgePosition = Vector2.zero;

    private void Awake()
    {
        baseCollider = basePaddle.GetComponent<BoxCollider2D>();
        sideCollider = sidePaddle.GetComponent<BoxCollider2D>();
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
                paddleEdgePosition = new Vector2(baseCollider.bounds.min.x - sideCollider.bounds.extents.x, basePaddle.transform.position.y);
                sidePaddle.transform.position = new Vector2(paddleEdgePosition.x, paddleEdgePosition.y);
                break;
            case DirectionType.Right:
                paddleEdgePosition = new Vector2(baseCollider.bounds.max.x + sideCollider.bounds.extents.x, basePaddle.transform.position.y);
                sidePaddle.transform.position = new Vector2(paddleEdgePosition.x, paddleEdgePosition.y);
                break;
        }
    }
}
