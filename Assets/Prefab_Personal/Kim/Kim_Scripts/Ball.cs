using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Vector2 myPos;

    public float speed;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // TODO :: Reset(spawn Position);
        Reset(transform.position);
        LaunchBall();
    }

    public void LaunchBall()
    {
        Vector2 jumpVelocity = Vector2.up * speed;
        jumpVelocity.x = Random.Range(-4f, 4f);

        rigid2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    public void Reset(Vector2 inPosition)
    {
        // TODO :: paddle Position Reset
        rigid2D.velocity = Vector2.zero;
        transform.position = inPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.TryGetComponent<???>(out var out???))
        //{
        //GameManager.instance.currentScore += out???.score;

        // TODO :: target = collision.gameObject.layer
        if (collision.gameObject.layer == 8)
        {
            // TODO :: 5 = collision.gameObject.class.Score
            //GameManager.Instance.currentScore += 5;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.MissBall(gameObject);
    }
}
