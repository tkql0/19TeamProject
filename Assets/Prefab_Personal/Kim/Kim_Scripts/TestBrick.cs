using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBrick : MonoBehaviour
{
    public int heart;
    public int score = 5;

    //private Animator anim;
    private BoxCollider2D boxCollider;

    public float speed = 0.1f;

    public bool isSpecialLevel;

    private void Awake()
    {
        //anim = GetCompoment<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        boxCollider.enabled = true;
        //anim.isDie.SetBool(false);
        heart = 1;
        // ���� ������ �ִ� ��ũ��Ʈ���� �޾ƿ���
        isSpecialLevel = true;
    }

    private void Update()
    {
        Movement();

        if (heart <= 0)
        {
            // �ݶ��̴��� ������� ���� ����� ���� Ȯ��
            boxCollider.enabled = false;
            // �ִϸ��̼��� �ִ� ������Ʈ�� �����ϸ� �ǳ�?
            //anim.isDie.SetBool(true);
            Invoke("Dead", 2f);
            return;
        }
    }

    private void Movement()
    { // ���ݾ� ������ �������� �ϱ�
        transform.position = Vector2.MoveTowards(transform.position
            , transform.position + new Vector3(0, -1), 0.1f * Time.deltaTime);
    }

    public void Dead()
    {
        GameManager.Instance.currentScore += score;
        gameObject.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D inCollision)
    {
        if (inCollision.gameObject.TryGetComponent<Ball>(out var outBall))
        {
            if (isSpecialLevel)
            { // Ư�� ������ ��� ������ ���� ����
                return;
            }

            if (heart > 0)
            {
                heart -= outBall.damage;
            }
        }
    }

    // �׷��� ����� �ٴڿ� ����� ��Ȳ�� �־���
    private void OnTriggerEnter2D(Collider2D incollision)
    { // ������ �ٴڿ� ��Ҵ°�?
        GameManager.Instance.GameOver();
    }
}

