using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    public Vector2 myPos;

    public float minSpeed;

    public int damage = 0;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (GameManager.Instance.isGameStart)
        {
            Reset(myPos);
            LaunchBall();
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = transform.position;
        float speed = moveVec.magnitude;

        if (speed < minSpeed)
        {
            if (Mathf.Abs(rigid2D.velocity.x) < minSpeed)
            {
                rigid2D.velocity = new Vector2(Mathf.Sign(rigid2D.velocity.x)
                    * minSpeed, rigid2D.velocity.y);
            }
            else if (Mathf.Abs(rigid2D.velocity.y) < minSpeed)
            {
                rigid2D.velocity = new Vector2(rigid2D.velocity.x,
                    Mathf.Sign(rigid2D.velocity.y) * minSpeed);
            }
        }
    }

    public void LaunchBall()
    {
        Vector2 jumpVelocity = Vector2.up * minSpeed;
        jumpVelocity.x = Random.Range(-4f, 4f);

        rigid2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    public void Reset(Vector2 inPosition)
    {
        // TODO :: 패들 위치에서 생성? 생성 위치는 발라 질 수 있음
        rigid2D.velocity = Vector2.zero;
        transform.position = inPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.TryGetComponent<???>(out var out???))
        //{
        //GameManager.instance.currentScore += out???.score;

        // TODO :: target = collision.gameObject.layer
        //if (collision.gameObject.layer == 8)
        //{
        // TODO :: 5 = collision.gameObject.class.Score
        //GameManager.Instance.currentScore += 5;
        //Destroy(collision.gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager.Instance.MissBall(gameObject);
    }
}
