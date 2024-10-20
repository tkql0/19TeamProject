using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigid2D;

    public float minSpeed;

    public int damage = 0;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        LaunchBall();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.isGameStart)
        {
            return;
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameManager.Instance.MissBall(gameObject);
    }
}
