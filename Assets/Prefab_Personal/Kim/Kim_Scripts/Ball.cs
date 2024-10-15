using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigid2D;

    Vector2 myPos;

    [SerializeField]LayerMask target;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    private void Update()
    {
        myPos = transform.position;

        // TODO :: 사라질 높이 변경
        if(myPos.y < -5f)
        {
            //GameManager.instance.MissBall(this.gameObject);
        }
    }

    private void LaunchBall()
    {
        Vector2 jumpVelocity = Vector2.up * speed;
        jumpVelocity.x = Random.Range(-2f, 2f);

        rigid2D.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.TryGetComponent<???>(out var out???))
        //{
        //GameManager.instance.currentScore += out???.score;
        //GameManager.instance.currentScore += 5;
        if (collision.gameObject.layer == target)
        {
            Destroy(collision.gameObject);
        }
        //}
    }
}
