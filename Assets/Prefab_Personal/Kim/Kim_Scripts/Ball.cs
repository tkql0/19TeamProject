using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigid2D;
    private Animator anim;

    public float minSpeed;
    public float maxSpeed;

    public int damage = 0;

    public int DoubleBallCount;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        LaunchBall();
        anim.SetBool("isBoom", false);
    }

    private void Update()
    {
        //    anim.SetBool("isBoom", true);
    }

    private void FixedUpdate()
    {
        if (rigid2D.velocity.magnitude < minSpeed)
        {
            rigid2D.velocity = rigid2D.velocity.normalized * minSpeed;
        }
        else if (rigid2D.velocity.magnitude > maxSpeed)
        {
            rigid2D.velocity = rigid2D.velocity.normalized * maxSpeed;
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
        if(!collision.TryGetComponent<ItemSOHolder>(out var outItem))
        {
            GameManager.Instance.MissBall(gameObject);
        }
    }
}
