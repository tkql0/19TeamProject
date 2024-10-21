using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private float speed = 3f;

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D inCollision)
    {
        int paddleLayer = LayerMask.NameToLayer("Paddle");
        int wallLayer = LayerMask.NameToLayer("Wall");

        if (inCollision.gameObject.layer == paddleLayer)
        {
            DestroyItem();
        }
        else if (inCollision.gameObject.layer == wallLayer)
        {
            DestroyItem(1f);
        }
    }

    private void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void DestroyItem(float inDelayTime)
    {
        Destroy(gameObject, inDelayTime);
    }
}
